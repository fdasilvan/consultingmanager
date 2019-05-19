import { Component, OnInit } from '@angular/core';
import { TimelineService } from '../../services/timeline/timeline.service';
import { Process } from 'src/app/models/process.model';
import { Customer } from 'src/app/models/customer.model';
import { Task } from 'src/app/models/task.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'app-timeline',
    templateUrl: './timeline.component.html',
    styleUrls: ['./timeline.component.css']
})
export class TimelineComponent implements OnInit {

    constructor(private service: TimelineService,
        private route: ActivatedRoute,
        private router: Router) { }

    public customer: Customer;
    public processesList: Process[];
    ngOnInit() {
        this.getCustomerId();
        this.loadProcesses(this.customer);
    }

    async loadProcesses(customer: Customer) {
        this.processesList = await this.service.getProcesses(customer.id);
    }

    getCustomerId() {
        this.customer = <Customer>JSON.parse(localStorage.getItem("customer"));
        if (!this.customer) {
            this.customer = window.history.state.customer;
        }
    }

    updateSelectedTask(task: Task, event: Event) {
        event.preventDefault();
        this.router.navigate(['task'])
        window.localStorage.setItem('task', JSON.stringify(task));
    }

    loadClassIndicator(task: Task) {
        let today: Date = new Date();
        today.setHours(0, 0, 0, 0);

        if (!task.endDate) {
            if (today > new Date(task.estimatedEndDate)) {
                return "indicator label-danger";
            } else if (today.getTime() >= new Date(task.startDate).getTime()) {
                return "indicator label-warning";
            } else {
                return "indicator label-default";
            }
        } else {
            return "indicator label-success";
        }
    }
}
