import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CustomersService } from 'src/app/services/customers/customers.service';
import { Customer } from 'src/app/models/customer.model';
import { CustomerMeeting } from 'src/app/models/customermeeting.model';
import { CustomerProcess } from 'src/app/models/customerprocess.model';
import { NgbModalRef, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ProcessService } from 'src/app/services/process/process.service';
import { ModelProcess } from 'src/app/models/modelprocess.model';
import { UserService } from 'src/app/services/user/user.service';
import { User } from 'src/app/models/user.model';

@Component({
  selector: 'app-flightplan',
  templateUrl: './flightplan.component.html',
  styleUrls: ['./flightplan.component.css']
})
export class FlightplanComponent implements OnInit {

  public loggedUser: User;
  constructor(private router: Router,
    private userService: UserService,
    private processService: ProcessService,
    private customersService: CustomersService,
    private modalService: NgbModal) {

    this.loggedUser = this.userService.getUser();

    if (!this.loggedUser) {
      this.router.navigate(['login']);
    }
  }

  public customer: Customer;
  public meetings: CustomerMeeting[] = [];
  public customerProcesses: CustomerProcess[] = []
  public filteredCustomerProcesses: CustomerProcess[] = []
  public modelProcessesList: ModelProcess[] = [];
  public selectedMeeting: CustomerMeeting;
  public modalObject: NgbModalRef;
  public today: Date = new Date();

  ngOnInit() {
    this.loadCustomer();
    this.loadMeetings();
    this.loadCustomerProcesses();
    this.loadModelProcesses();
  }

  loadCustomer() {
    if (window.sessionStorage.getItem('customer') != 'undefined') {
      this.customer = <Customer>JSON.parse(window.sessionStorage.getItem('customer'));
    }
  }

  async loadModelProcesses() {
    this.modelProcessesList = await this.processService.getModelProcesses();
  }

  async loadCustomerProcesses() {
    this.customerProcesses = await this.processService.getCustomerProcesses(this.customer.id);
    if (this.selectedMeeting) {
      this.filteredCustomerProcesses = this.customerProcesses.filter(o => o.customerMeetingId == this.selectedMeeting.id);
    }
  }

  async loadMeetings() {
    this.meetings = await this.customersService.getMeetings(this.customer.id);
  }

  selectMeeting(meeting: CustomerMeeting) {
    this.selectedMeeting = meeting;
    this.filteredCustomerProcesses = this.customerProcesses.filter(o => o.customerMeetingId == this.selectedMeeting.id);
  }

  openProcessModal(content) {
    this.modalObject = this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
  }

  async addProcess(modelProcessId: string, modelDescription: string, detail: string, customerUserId: string, startDate: string) {
    if (modelProcessId == '' || customerUserId == '') {
      alert('O modelo e o usuário do cliente são obrigatórios!');
    } else {
      this.modalObject.close();
      await this.processService.startCustomerProcess(modelProcessId, modelDescription, detail, this.customer.id, this.loggedUser.id, customerUserId, new Date(startDate), this.selectedMeeting.id);
      await this.loadCustomerProcesses();
    }
  }

  goBack() {
    window.history.back();
  }

  registerMeetings() {
    window.sessionStorage.setItem('customer', JSON.stringify(this.customer));
    this.router.navigate(['customer-meetings']);
  }
}
