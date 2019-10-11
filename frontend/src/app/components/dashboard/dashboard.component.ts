import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';
import { CustomersService } from 'src/app/services/customers/customers.service';
import { DashboardService } from 'src/app/services/dashboard/dashboard.service';
import { CustomerTask } from 'src/app/models/customertask.model';
import { DashboardsTasks } from 'src/app/models/dashboard-tasks.model';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { Customer } from 'src/app/models/customer.model';
import * as moment from 'moment';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private userService: UserService,
    private customerService: CustomersService,
    private dashboardService: DashboardService,
    private modalService: NgbModal,
    private router: Router) {
    this.loggedUser = this.userService.getLoggedUser();

    if (!this.loggedUser) {
      this.router.navigate(['login']);
    }
  }

  public loggedUser: User;
  public modalObject: NgbModalRef;
  public selectedConsultant: User;
  public customerTasks: CustomerTask[] = [];
  public consultantsList: User[] = [];
  public dashboardConsultantsTasks: DashboardsTasks[] = [];
  public dashboardDueTasks: CustomerTask[] = [];

  async ngOnInit() {
    await this.loadConsultantTasks();
    await this.calculateTasksByConsultant();
  }

  async loadConsultantTasks() {
    this.customerTasks = await this.dashboardService.getConsultantsTasks();
    this.consultantsList = await this.customerService.getConsultants();
  }

  async calculateTasksByConsultant() {
    for (let i = 0; i < this.consultantsList.length; i++) {
      let consultant = this.consultantsList[i];
      let consultantTasks = this.customerTasks.filter(o => o.consultant.id == consultant.id);

      let notStartedTasks = 0;
      let onTimeTasks = 0;
      let dueTasks = 0;

      let now = moment(new Date());

      for (let j = 0; j < consultantTasks.length; j++) {
        let task = consultantTasks[j];

        let startDate = moment.utc(new Date(task.startDate));
        let estimatedEndDate = moment.utc(new Date(task.estimatedEndDate));

        if (startDate.isAfter(now, 'day')) {
          notStartedTasks++;
        } else if (startDate.isBefore(now, 'day') && estimatedEndDate.isAfter(now, 'day')) {
          onTimeTasks++;
        } else if (estimatedEndDate.isBefore(now, 'day')) {
          dueTasks++;
        }
      }

      let dashboardTask = new DashboardsTasks();

      dashboardTask.consultantId = consultant.id;
      dashboardTask.consultant = consultant;
      dashboardTask.notStartedTasks = notStartedTasks;
      dashboardTask.onTimeTasks = onTimeTasks;
      dashboardTask.dueTasks = dueTasks;

      this.dashboardConsultantsTasks.push(dashboardTask);
    }
  }

  consultantSelected(consultant: User, event: Event, content: any) {
    event.preventDefault();
    this.selectedConsultant = consultant;
    
    let now = moment(new Date());

    this.dashboardDueTasks = this.customerTasks.filter(o => o.consultant.id == consultant.id && o.endDate == null && moment.utc(new Date(o.estimatedEndDate)).isBefore(now, 'day'));
    this.dashboardDueTasks = this.dashboardDueTasks.sort((a, b) => a.customer.name.localeCompare(b.customer.name));
    this.modalObject = this.modalService.open(content, { size: 'lg', ariaLabelledBy: 'modal-basic-title' });
  }

  customerSelected(customer: Customer, event: Event) {
    event.preventDefault();
    this.modalObject.close();
    window.sessionStorage.setItem('customer', JSON.stringify(customer));
    this.router.navigate(['timeline']);
  }
}
