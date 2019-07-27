import { Component, OnInit } from '@angular/core';
import { CustomerTask } from 'src/app/models/customertask.model';
import { Customer } from 'src/app/models/customer.model';
import { TaskService } from 'src/app/services/task/task.service';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';
import { NgbModalRef, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})

export class TaskComponent implements OnInit {
  public loggedUser: User;
  constructor(private taskService: TaskService,
    private userService: UserService,
    private modalService: NgbModal,
    private router: Router) {

    this.loggedUser = this.userService.getUser();

    if (!this.loggedUser) {
      this.router.navigate(['login']);
    }
  }

  public today: Date = new Date();
  public modalObject: NgbModalRef;
  public taskId: string;
  public task: CustomerTask;
  public customer: Customer;

  public canFinishTask = false;
  public canReopenTask = false;
  public canRescheduleTask = false;
  public showActionsMenu = false;

  ngOnInit() {
    this.loadTask();
  }

  async finishTask(taskId: string) {
    await this.taskService.finishTask(taskId);
    this.goBack();
  }

  async reopenTask(taskId: string) {
    await this.taskService.reopenTask(taskId);
    this.goBack();
  }

  rescheduleTaskModal(content) {
    this.modalObject = this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
  }

  async rescheduleTask(newDate: Date) {
    this.taskService.rescheduleTask(this.task.id, newDate)
      .then(result => {
        alert("Tarefa reprogramada com sucesso!");
      })
      .catch(result => {
        alert(result.error);
      });
    this.modalObject.close();
  }

  async loadTask() {
    this.customer = <Customer>JSON.parse(window.sessionStorage.getItem('customer'));
    this.taskId = window.localStorage.getItem('taskId');
    this.task = await this.taskService.getTask(this.taskId);
    this.checkPermissions();
  }

  checkPermissions() {
    if (this.loggedUser.userType.description == "Cliente" && this.task.taskType.description != "Consultor") {
      if (this.task.endDate) {
        this.canReopenTask = true;
        this.showActionsMenu = true;
      } else {
        this.canFinishTask = true;
        this.showActionsMenu = true;
      }
    }

    if (this.loggedUser.userType.description != "Cliente") {
      if (this.task.endDate) {
        this.canReopenTask = true;
        this.showActionsMenu = true;
      } else {
        this.canFinishTask = true;
        this.canRescheduleTask = true;
        this.showActionsMenu = true;
      }
    }
  }

  goBack() {
    window.history.back();
  }
}
