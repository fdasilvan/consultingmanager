import { Component, OnInit } from '@angular/core';
import { TimelineService } from './timeline.service';
import { Process } from 'src/app/models/process.model';
import { Customer } from 'src/app/models/customer.model';

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
}
