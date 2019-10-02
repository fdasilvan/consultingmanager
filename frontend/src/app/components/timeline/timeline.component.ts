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
import { CustomersService } from 'src/app/services/customers/customers.service';
import { TaskService } from 'src/app/services/task/task.service';

@Component({
  selector: 'app-timeline',
  templateUrl: './timeline.component.html',
  styleUrls: ['./timeline.component.css']
})
export class TimelineComponent implements OnInit {

  public loggedUser: User;
  constructor(private processService: ProcessService,
    private customerService: CustomersService,
    private taskService: TaskService,
    private userService: UserService,
    private modalService: NgbModal,
    private route: ActivatedRoute,
    private router: Router) {

    this.loggedUser = this.userService.getLoggedUser();

    if (!this.loggedUser) {
      this.router.navigate(['login']);
    }
  }

  public customer: Customer;
  public customerProcessesList: CustomerProcess[];
  public modelProcessesList: ModelProcess[];
  public consultantsList: User[];
  public today: Date = new Date();
  public modalObject: NgbModalRef;
  public canDeleteProcess: boolean;
  public canAssignTask: boolean;
  public canAddTaskWithoutMeeting: boolean;
  public selectedModelProcessId: string;
  public selectedCustomerProcessId: string;
  public selectedCustomerStepId: string;

  closeResult: string;

  async ngOnInit() {
    await this.loadCustomer();
    this.loadModelProcesses();
    this.loadCustomerProcesses(this.customer);
    this.loadConsultants();
    this.getUserPermissions();
  }

  getUserPermissions() {
    this.canDeleteProcess = this.loggedUser.userType.description == "Administrador" || this.loggedUser.userType.description == "Líder";
    this.canAssignTask = this.loggedUser.userType.description == "Administrador" || this.loggedUser.userType.description == "Líder";
    this.canAddTaskWithoutMeeting = this.loggedUser.userType.description == "Administrador" || this.loggedUser.userType.description == "Líder" || this.loggedUser.userType.description == 'Implantador';
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

  async loadConsultants() {
    this.consultantsList = await this.customerService.getConsultants();
  }

  openModal(content) {
    this.modalObject = this.modalService.open(content, { size: 'lg', ariaLabelledBy: 'modal-basic-title' });
  }

  openRescheduleProcessModal(content, customerProcessId: string) {
    this.selectedCustomerProcessId = customerProcessId;
    this.modalObject = this.modalService.open(content, { size: 'lg', ariaLabelledBy: 'modal-basic-title' });
  }

  openRescheduleStepModal(content, customerStepId: string) {
    this.selectedCustomerStepId = customerStepId;
    this.modalObject = this.modalService.open(content, { size: 'lg', ariaLabelledBy: 'modal-basic-title' });
  }

  async rescheduleProcess(businessDaysToAdd: number) {
    if (businessDaysToAdd < 1 || businessDaysToAdd > 60) {
      alert("O replanejamento deve ser de 1 dia útil a 60 dias úteis.");
      return;
    }
    this.modalObject.close();
    await this.taskService.rescheduleProcess(this.selectedCustomerProcessId, businessDaysToAdd);
    alert('Ação replanejada com sucesso!');
    this.loadCustomerProcesses(this.customer);
  }

  async rescheduleStep(businessDaysToAdd: number) {
    if (businessDaysToAdd < 1 || businessDaysToAdd > 60) {
      alert("O replanejamento deve ser de 1 dia útil a 60 dias úteis.");
      return;
    }
    this.modalObject.close();
    await this.taskService.rescheduleStep(this.selectedCustomerStepId, businessDaysToAdd);
    alert('Etapa replanejada com sucesso!');
    this.loadCustomerProcesses(this.customer);
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

  async deleteProcess(customerProcessId: string) {
    let result = confirm('Tem certeza que quer excluir a ação?');
    if (result) {
      await this.processService.delete(customerProcessId);
      this.loadCustomerProcesses(this.customer);
    }
  }

  async finishTask(taskId: string, event: Event) {
    window.sessionStorage.setItem('timeline_scroll', window.pageYOffset.toString());
    event.preventDefault();
    let result = confirm('Tem certeza que deseja finalizar a tarefa?');

    if (result) {
      await this.taskService.finishTask(taskId);
      await this.loadCustomerProcesses(this.customer);

      let scrollY = window.sessionStorage.getItem('timeline_scroll');
      if (scrollY && scrollY != 'null') {
        window.scrollTo(0, parseInt(scrollY));
      }
    }
  }

  async finishStep(stepId: string, event: Event) {
    window.sessionStorage.setItem('timeline_scroll', window.pageYOffset.toString());
    event.preventDefault();
    let result = confirm('Tem certeza que deseja finalizar as tarefas desta etapa?');

    if (result) {
      await this.processService.finishStep(stepId);
      await this.loadCustomerProcesses(this.customer);

      let scrollY = window.sessionStorage.getItem('timeline_scroll');
      if (scrollY && scrollY != 'null') {
        window.scrollTo(0, parseInt(scrollY));
      }
    }
  }

  updateSelectedModelProcess(modelProcessId: string) {
    this.selectedModelProcessId = modelProcessId;
  }

  async loadCustomer() {
    this.customer = <Customer>JSON.parse(window.sessionStorage.getItem('customer'));
    this.customer = await this.customerService.getCustomer(this.customer.id);
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

  editCustomer() {
    window.sessionStorage.setItem('customer', JSON.stringify(this.customer));
    this.router.navigate(['customer-registration']);
  }

  async transferCustomer(consultantId: string) {
    if (consultantId == '') {
      alert('É necessário selecionar o consultor.');
    }

    await this.customerService.transferCustomer(this.customer.id, consultantId);
    this.modalObject.close();
    alert('Cliente transferido com sucesso!');
    this.router.navigate(['customers']);
  }

  customerMeetings() {
    window.sessionStorage.setItem('customer', JSON.stringify(this.customer));
    this.router.navigate(['customer-meetings']);
  }

  customerFlightplan() {
    window.sessionStorage.setItem('customer', JSON.stringify(this.customer));
    this.router.navigate(['flightplan']);
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
      return 'fa fa-check success-green';
    }
  }
}
