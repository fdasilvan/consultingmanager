import { Component, OnInit } from '@angular/core';
import { Task } from 'src/app/models/task.model';
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
  public task: Task;
  public customer: Customer;

  public canFinishTask = false;
  public canReopenTask = false;
  public canRescheduleTask = false;
  public showActionsMenu = false;

  ngOnInit() {
    this.loadTasks();
    this.checkPermissions();
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
    await this.taskService.rescheduleTask(this.task.id, newDate);
    this.modalObject.close();
  }

  loadTasks() {
    this.customer = <Customer>JSON.parse(window.localStorage.getItem('customer'));
    this.task = <Task>JSON.parse(window.localStorage.getItem('task'));
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
