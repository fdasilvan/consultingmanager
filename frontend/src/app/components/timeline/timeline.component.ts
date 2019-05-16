import { Component, OnInit } from '@angular/core';
import { TimelineService } from '../../services/timeline.service';
import { Process } from 'src/app/models/process.model';
import { Customer } from 'src/app/models/customer.model';
import { Task } from 'src/app/models/task.model';

@Component({
    selector: 'app-timeline',
    templateUrl: './timeline.component.html',
    styleUrls: ['./timeline.component.css']
})
export class TimelineComponent implements OnInit {

    constructor(private service: TimelineService) { }

    public customer: Customer;
    public processesList: Process[];
    ngOnInit() {
        this.getCustomerId();
        this.loadProcesses(this.customer);
    }

    async loadProcesses(customer: Customer) {
        this.processesList = await this.service.getAll();
    }

    getCustomerId() {
        debugger;
        this.customer = <Customer>JSON.parse(localStorage.getItem("customer"));
        if (!this.customer) {
            this.customer = window.history.state.customer;
        }
    }

    loadClassIndicator(task: Task) {
        let today: Date = new Date();
        today.setHours(0, 0, 0, 0);

        if (!task.executionDate) {
            if (today > task.endDate) {
                return "indicator label-danger";
            } else if (today.getTime() >= task.startDate.getTime()) {
                return "indicator label-warning";
            } else {
                return "indicator label-default";
            }
        } else {
            return "indicator label-success";
        }
    }
}
