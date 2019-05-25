import { Component, OnInit, ViewChild } from '@angular/core';
import { ProcessService } from '../../services/process/process.service';
import { CustomerProcess } from 'src/app/models/customerprocess.model';
import { Customer } from 'src/app/models/customer.model';
import { Task } from 'src/app/models/task.model';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { ModelProcess } from 'src/app/models/modelprocess.model';

@Component({
  selector: 'app-timeline',
  templateUrl: './timeline.component.html',
  styleUrls: ['./timeline.component.css']
})
export class TimelineComponent implements OnInit {

  public loggedUser: User;
  constructor(private processService: ProcessService,
    private userService: UserService,
    private modalService: NgbModal,
    private route: ActivatedRoute,
    private router: Router) {

    this.loggedUser = this.userService.getUser();

    if (!this.loggedUser) {
      this.router.navigate(['login']);
    }
  }

  public customer: Customer;
  public customerProcessesList: CustomerProcess[];
  public modelProcessesList: ModelProcess[];
  public today: Date = new Date();
  
  closeResult: string;

  ngOnInit() {
    this.getCustomerId();
    this.loadModelProcesses();
    this.loadCustomerProcesses(this.customer);
  }

  async loadModelProcesses() {
    this.modelProcessesList = await this.processService.getModelProcesses();
  }

  async loadCustomerProcesses(customer: Customer) {
    this.customerProcessesList = await this.processService.getCustomerProcesses(customer.id);
  }

  async startCustomerProcess(modelProcessId: string, modelDescription: string, customerUserId: string, startDate: string) {
    debugger;
    await this.processService.startCustomerProcess(modelProcessId, modelDescription, this.customer.id, this.loggedUser.id, customerUserId, new Date(startDate));
  }

  getCustomerId() {
    this.customer = <Customer>JSON.parse(localStorage.getItem("customer"));
    if (!this.customer) {
      this.customer = window.history.state.customer;
    }
  }

  updateSelectedTask(task: Task, event: Event) {
    event.preventDefault();
    this.router.navigate(['task'])
    window.localStorage.setItem('task', JSON.stringify(task));
  }

  loadClassIndicator(task: Task) {
    let today: Date = new Date();
    today.setHours(0, 0, 0, 0);

    if (!task.endDate) {
      if (today > new Date(task.estimatedEndDate)) {
        return "indicator label-danger";
      } else if (today.getTime() >= new Date(task.startDate).getTime()) {
        return "indicator label-warning";
      } else {
        return "indicator label-default";
      }
    } else {
      return "indicator label-success";
    }
  }

  openProcessModal(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed`;
    });
  }
}
