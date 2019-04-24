import { Component, OnInit } from '@angular/core';
import { CustomersService } from './customers.service';
import { Customer } from 'src/app/models/customer.model';

@Component({
    selector: 'app-customers',
    templateUrl: './customers.component.html',
    styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

    constructor(private service: CustomersService) { }

    public customersUrl: string = "http://localhost:3000/customers";
    public customers: Customer[];

    ngOnInit() {
        this.loadCustomers();
    }

    async loadCustomers() {
        this.customers = await this.service.getAll();
    }
}
