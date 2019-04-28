import { Component, OnInit } from '@angular/core';
import { Task } from 'src/app/models/task.model';
import { Customer } from 'src/app/models/customer.model';

@Component({
    selector: 'app-task',
    templateUrl: './task.component.html',
    styleUrls: ['./task.component.css']
})

export class TaskComponent implements OnInit {

    constructor() { }

    public task: Task;
    public customer: Customer;

    ngOnInit() {
        this.loadTask();
    }

    loadTask() {
        this.customer = <Customer>JSON.parse(window.localStorage.getItem('customer'));
        this.task = <Task>JSON.parse(window.localStorage.getItem('task'));
    }
}
