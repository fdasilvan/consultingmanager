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

    this.loggedUser = this.userService.getLoggedUser();

    if (!this.loggedUser) {
      this.router.navigate(['login']);
    }
  }

  public customer: Customer;
  public selectedContractId: string;
  public meetings: CustomerMeeting[] = [];
  public customerProcesses: CustomerProcess[] = []
  public filteredCustomerProcesses: CustomerProcess[] = []
  public modelProcessesList: ModelProcess[] = [];
  public selectedMeeting: CustomerMeeting;
  public modalObject: NgbModalRef;
  public today: Date = new Date();
  public selectedModelProcessId: string;

  async ngOnInit() {
    await this.loadCustomer();
    await this.loadContract();
    await this.loadCustomerProcesses();
    await this.loadMeetings();
    await this.loadModelProcesses();
  }

  loadCustomer() {
    if (window.sessionStorage.getItem('customer') != 'undefined') {
      this.customer = <Customer>JSON.parse(window.sessionStorage.getItem('customer'));
    }
  }

  loadContract() {
    if (window.sessionStorage.getItem('contract') != 'undefined') {
      this.selectedContractId = window.sessionStorage.getItem('contract');
    } else {
      this.selectedContractId = '';
    }
  }

  async loadModelProcesses() {
    this.modelProcessesList = await this.processService.getModelProcesses();
  }

  async loadCustomerProcesses() {
    this.customerProcesses = await this.processService.getCustomerProcesses(this.customer.id, this.selectedContractId);
    if (this.selectedMeeting) {
      this.filteredCustomerProcesses = this.customerProcesses.filter(o => o.customerMeetingId == this.selectedMeeting.id);
    }
  }

  async loadMeetings() {
    this.meetings = await this.customersService.getMeetings(this.customer.id, this.selectedContractId);
    this.meetings.forEach(meeting => {
      meeting.processes = this.customerProcesses.filter(o => o.customerMeetingId == meeting.id);
    });
  }

  selectMeeting(meeting: CustomerMeeting) {
    this.selectedMeeting = meeting;
    this.filteredCustomerProcesses = this.customerProcesses.filter(o => o.customerMeetingId == this.selectedMeeting.id);
  }

  openModal(content) {
    this.modalObject = this.modalService.open(content, { size: 'lg', ariaLabelledBy: 'modal-basic-title' });
  }

  updateSelectedModelProcess(modelProcessId: string) {
    this.selectedModelProcessId = modelProcessId;
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

  async getMeetingProcesses(customerMeetingId: string) {
    let meetingProcesses = this.customerProcesses.filter(o => o.customerMeetingId == customerMeetingId);
    return meetingProcesses;
  }

  async onMeetingFinishedChanged(isFinished: boolean) {    
    this.selectedMeeting.isFinished = isFinished;
    let arr: CustomerMeeting[] = [];
    arr.push(this.selectedMeeting);
    await this.customersService.saveMeetings(this.customer.id, arr);
    await this.loadMeetings();
  }

  goBack() {
    window.history.back();
  }

  substringText(text: string, length: number) {
    return text.substr(0, length);
  }

  mustShowMeeting(meetingDate: Date) {
    let date = new Date(meetingDate);
    let dateLimit = new Date();
    dateLimit.setMonth(dateLimit.getMonth() + 1);
    return date.getTime() < dateLimit.getTime();
  }

  registerMeetings() {
    window.sessionStorage.setItem('customer', JSON.stringify(this.customer));
    this.router.navigate(['customer-meetings']);
  }
}
