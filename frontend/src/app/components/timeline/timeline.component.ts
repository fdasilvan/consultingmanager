import { Component, OnInit, ViewChild } from '@angular/core';
import { ProcessService } from '../../services/process/process.service';
import { CustomerProcess } from 'src/app/models/customerprocess.model';
import { Customer } from 'src/app/models/customer.model';
import { CustomerTask } from 'src/app/models/customertask.model';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';
import { NgbModal, ModalDismissReasons, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
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
  public modalObject: NgbModalRef;

  closeResult: string;

  ngOnInit() {
    this.getCustomerId();
    this.loadModelProcesses();
    this.loadCustomerProcesses(this.customer);
  }

  ngAfterViewChecked() {
    let scrollY = window.sessionStorage.getItem('timeline_scroll');
    if (scrollY && scrollY != 'null') {
      window.scrollTo(0, parseInt(scrollY));
    }
  }

  async loadModelProcesses() {
    this.modelProcessesList = await this.processService.getModelProcesses();
  }

  async loadCustomerProcesses(customer: Customer) {
    this.customerProcessesList = await this.processService.getCustomerProcesses(customer.id);
  }

  openProcessModal(content) {
    this.modalObject = this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
  }

  async startCustomerProcess(modelProcessId: string, modelDescription: string, customerUserId: string, startDate: string) {
    await this.processService.startCustomerProcess(modelProcessId, modelDescription, this.customer.id, this.loggedUser.id, customerUserId, new Date(startDate));
    this.modalObject.close();
    this.router.navigate(['worklist']);
  }

  getCustomerId() {
    this.customer = <Customer>JSON.parse(window.sessionStorage.getItem('customer'));
    if (!this.customer) {
      this.customer = window.history.state.customer;
    }
  }

  updateSelectedTask(task: CustomerTask, event: Event) {
    event.preventDefault();
    this.router.navigate(['task']);
    window.localStorage.setItem('taskId', task.id);
    window.sessionStorage.setItem('timeline_scroll', window.pageYOffset.toString());
  }

  toggleElement(element) {
    element.parentElement.nextElementSibling.style.display = (element.parentElement.nextElementSibling.style.display == 'none' ? '' : 'none');
    element.className = (element.className == 'fa fa-chevron-right' ? 'fa fa-chevron-down' : 'fa fa-chevron-right');
  }

  loadClassIndicator(task: CustomerTask) {
    let today: Date = new Date();
    today.setHours(0, 0, 0, 0);

    if (!task.endDate) {
      if (today > new Date(task.estimatedEndDate)) {
        return 'indicator label-danger';
      } else if (today.getTime() >= new Date(task.startDate).getTime()) {
        return 'indicator label-warning';
      } else {
        return 'indicator label-default';
      }
    } else {
      return 'indicator label-success';
    }
  }
}
