import { Component, OnInit } from '@angular/core';
import { Task } from 'src/app/models/task.model';
import { Customer } from 'src/app/models/customer.model';
import { TaskService } from 'src/app/services/task/task.service';
import { Router } from '@angular/router';
import { routerNgProbeToken } from '@angular/router/src/router_module';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';

@Component({
    selector: 'app-task',
    templateUrl: './task.component.html',
    styleUrls: ['./task.component.css']
})

export class TaskComponent implements OnInit {
    public loggedUser: User;
    constructor(private service: TaskService,
        private userService: UserService,
        private router: Router) {
            
        this.loggedUser = this.userService.getUser();

        if (!this.loggedUser) {
            this.router.navigate(['login']);
        }
    }

    public task: Task;
    public customer: Customer;

    ngOnInit() {
        this.loadTasks();
    }

    async finishTask(taskId: string) {
        await this.service.finishTask(taskId);
        this.router.navigate(['worklist']);
    }

    async rescheduleTask() {
      
    }

    loadTasks() {
        this.customer = <Customer>JSON.parse(window.localStorage.getItem('customer'));
        this.task = <Task>JSON.parse(window.localStorage.getItem('task'));
    }
}
