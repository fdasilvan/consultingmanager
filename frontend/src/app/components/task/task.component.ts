import { Component, OnInit } from '@angular/core';
import { Task } from 'src/app/models/task.model';
import { Customer } from 'src/app/models/customer.model';
import { TaskService } from 'src/app/services/task/task.service';
import { Router } from '@angular/router';
import { routerNgProbeToken } from '@angular/router/src/router_module';

@Component({
    selector: 'app-task',
    templateUrl: './task.component.html',
    styleUrls: ['./task.component.css']
})

export class TaskComponent implements OnInit {

    constructor(private service: TaskService,
        private router: Router) { }

    public task: Task;
    public customer: Customer;

    ngOnInit() {
        this.loadTasks();
    }

    async finishTask(taskId: string) {        
        await this.service.finishTask(taskId);
        this.router.navigate(['worklist']);
    }

    loadTasks() {
        this.customer = <Customer>JSON.parse(window.localStorage.getItem('customer'));
        this.task = <Task>JSON.parse(window.localStorage.getItem('task'));
    }
}
