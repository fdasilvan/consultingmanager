import { Component, OnInit, Input, Output, EventEmitter, NgModule } from '@angular/core';
import { User } from '../../../models/user.model';
import { Router } from '@angular/router';
import { UserService } from '../../../services/user/user.service';
import { ModelProcess } from '../../../models/modelprocess.model';
import { NgbModal, NgbModalRef, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ProcessService } from '../../../services/process/process.service';
import { Customer } from '../../../models/customer.model';
import { CustomerProcess } from '../../../models/customerprocess.model';
import { CustomersService } from '../../../services/customers/customers.service';
import { CustomerMeeting } from 'src/app/models/customermeeting.model';

@Component({
  selector: 'app-add-process',
  templateUrl: './add-process.component.html',
  styleUrls: ['./add-process.component.css']
})
export class AddProcessComponent implements OnInit {
  @Input() modal : NgbActiveModal;
  @Input() customerProcessesList : CustomerProcess[];
  @Input() customer : Customer;
  @Input() selectedMeeting: CustomerMeeting;

  @Output() reloadCustomerProcess = new EventEmitter<Customer>();

  public loggedUser: User;
  constructor(private userService: UserService,
    private processService: ProcessService,
    private customerService: CustomersService,
    private modalService: NgbModal,
    private router: Router) {

    this.loggedUser = this.userService.getLoggedUser();

    if (!this.loggedUser) {
      this.router.navigate(['login']);
    }
  }

  public modelProcessesList: ModelProcess[];
  public modelProcessesListData: ModelProcess[];
  public consultantsList: User[];
  public consultantProcessesListData: User[];
  public userProcessesListData: User[];
  public initialConsultant: User;
  public selectedCustomer: User;
  public today: Date = new Date();
  public canDeleteProcess: boolean;
  public canAssignTask: boolean;
  public modalObject : NgbModalRef;
  public canAddTaskWithoutMeeting: boolean;
  public selectedModelProcessId: string;
  public selectedModelProcessDesc: string;
  public selectedCustomerProcessId: string;
  public selectedConsultantProcessId: string;
  public selectedUserProcessId: string;
  public selectedCustomerStepId: string;
  public filterValue: string;

  ngOnInit() {
    this.loadModelProcesses();
    this.getUserPermissions();
    this.loadConsultants();
    this.modelProcessesListData = this.modelProcessesList;
    this.initialConsultant = this.loggedUser.userType.description === 'Consultor' ? this.loggedUser : null;
    if(this.customer.users.length == 1) {
      this.selectedCustomer = this.customer.users[0];
    }
  }

  async loadModelProcesses() {
    this.modelProcessesList = await this.processService.getModelProcesses();
  }

  async loadConsultants() {
    this.consultantsList = await this.customerService.getConsultants();
  }

  updateSelectedModelProcess(model: ModelProcess) {
    this.selectedModelProcessId = model.id;
    this.selectedModelProcessDesc =model.description;
  }

  getUserPermissions() {
    this.canDeleteProcess = this.loggedUser.userType.description == "Administrador" || this.loggedUser.userType.description == "Líder";
    this.canAssignTask = this.loggedUser.userType.description == "Administrador" || this.loggedUser.userType.description == "Líder";
    this.canAddTaskWithoutMeeting = this.loggedUser.userType.description == "Administrador" || this.loggedUser.userType.description == "Líder" || this.loggedUser.userType.description == 'Implantador';
  }

  openModal(content) {
    this.modalObject = this.modalService.open(content, { size: 'lg', ariaLabelledBy: 'modal-basic-title' });
  }

  async startCustomerProcess(modelProcessId: string, modelDescription: string, detail: string, consultantId: string, customerUserId: string, startDate: string) {
    if (modelProcessId == undefined || customerUserId == undefined || consultantId == undefined || modelProcessId == '' || customerUserId == '' || consultantId == '') {
      alert('Favor preencher todos os campos obrigatórios!');
    } else {
      this.modal.close()
      if(this.modalObject) {
        this.modalObject.close();
      }
      let ownerId = (consultantId && consultantId == '' ? this.loggedUser.id : consultantId);
      await this.processService.startCustomerProcess(modelProcessId, modelDescription, detail, this.customer.id, ownerId, customerUserId, new Date(startDate), this.selectedMeeting != undefined ? this.selectedMeeting.id: null);
      this.loadCustomerProcesses(this.customer);
    }
  }

  async loadCustomerProcesses(customer: Customer) {
    this.reloadCustomerProcess.emit(customer)
  }

  async onModelProcessChangeSearch(val: string) {
    this.modelProcessesListData = this.modelProcessesList.filter(this.generateFilterModelProcess(val));
  }

  onModelProcessFocused() {
    this.modelProcessesListData = this.modelProcessesList;
  }

  async onConsultantProcessChangeSearch(val: string) {
    this.consultantProcessesListData = this.consultantsList.filter(this.generateFilterUserProcess(val));
  }

  onConsultantProcessFocused() {
    this.consultantProcessesListData = this.consultantsList;
  }

  updateSelectedConsultantProcess(consultant: User) {
    this.selectedConsultantProcessId = consultant.id;
  }

  async onUserProcessChangeSearch(val: string) {
    this.userProcessesListData = this.customer.users.filter(this.generateFilterUserProcess(val));
  }

  onUserProcessFocused() {
    this.userProcessesListData = this.customer.users;
  }

  updateSelectedUserProcess(user: User) {
    this.selectedUserProcessId = user.id;
  }

  generateFilterModelProcess(query:string) {
    let lowerCaseQuery = query.toLowerCase()
    return function filterFn(model) {
      return (model.description.toLowerCase().indexOf(lowerCaseQuery) >= 0);
    };
  }

  generateFilterUserProcess(query:string) {
    let lowerCaseQuery = query.toLowerCase()
    return function filterFn(user) {
      return (user.name.toLowerCase().indexOf(lowerCaseQuery) >= 0);
    };
  }
}
