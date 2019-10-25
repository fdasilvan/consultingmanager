import { Component, OnInit, Input, Output, EventEmitter, NgModule } from '@angular/core';
import { User } from '../models/user.model';
import { Router } from '@angular/router';
import { UserService } from '../services/user/user.service';
import { ModelProcess } from '../models/modelprocess.model';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { ProcessService } from '../services/process/process.service';
import { Customer } from '../models/customer.model';
import { CustomerProcess } from '../models/customerprocess.model';

@Component({
  selector: 'app-add-action',
  templateUrl: './add-action.component.html',
  styleUrls: ['./add-action.component.css']
})
export class AddActionComponent implements OnInit {
  @Input() modal : any;
  @Input() customerProcessesList : CustomerProcess[];
  @Input() customer : Customer;

  @Output() reloadCustomerProcess = new EventEmitter<Customer>();

  public loggedUser: User;
  constructor(private userService: UserService,
    private processService: ProcessService,
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
  public today: Date = new Date();
  public modalObject: NgbModalRef;
  public canDeleteProcess: boolean;
  public canAssignTask: boolean;
  public canAddTaskWithoutMeeting: boolean;
  public selectedModelProcessId: string;
  public selectedCustomerProcessId: string;
  public selectedCustomerStepId: string;
  public filterValue: string;

  ngOnInit() {
    this.loadModelProcesses();
    this.modelProcessesListData = this.modelProcessesList;
  }

  async loadModelProcesses() {
    this.modelProcessesList = await this.processService.getModelProcesses();
  }

  updateSelectedModelProcess(modelProcessId: string) {
    this.selectedModelProcessId = modelProcessId;
  }

  openModal(content) {
    this.modalObject = this.modalService.open(content, { size: 'lg', ariaLabelledBy: 'modal-basic-title' });
  }

  async startCustomerProcess(modelProcessId: string, modelDescription: string, detail: string, consultantId: string, customerUserId: string, startDate: string) {
    if (modelProcessId == '' || customerUserId == '' || (this.canAssignTask && consultantId == '')) {
      alert('Favor preencher todos os campos obrigatórios!');
    } else {
      this.modalObject.close();
      let ownerId = (consultantId && consultantId == '' ? this.loggedUser.id : consultantId);
      await this.processService.startCustomerProcess(modelProcessId, modelDescription, detail, this.customer.id, ownerId, customerUserId, new Date(startDate), null);
      this.loadCustomerProcesses(this.customer);
    }
  }

  async loadCustomerProcesses(customer: Customer) {
    this.reloadCustomerProcess.emit(customer)
  }

  async onModelProcessChangeSearch(val: string) {
    this.modelProcessesListData = this.modelProcessesList.filter(this.generateFilter(val));
  }

  onModelProcessFocused() {
    this.modelProcessesListData = this.modelProcessesList;
  }

  generateFilter(query:string) {
    let lowerCaseQuery = query.toLowerCase()
    return function filterFn(model) {
      return (model.description.toLowerCase().indexOf(lowerCaseQuery) >= 0);
    };

  }
}
