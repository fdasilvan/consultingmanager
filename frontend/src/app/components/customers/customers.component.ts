import { Component, OnInit } from '@angular/core';
import { CustomersService } from '../../services/customers/customers.service';
import { Customer } from 'src/app/models/customer.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'app-customers',
    templateUrl: './customers.component.html',
    styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

    constructor(private service: CustomersService,
        private route: ActivatedRoute,
        private router: Router) { }
        
    public customers: Customer[];

    ngOnInit() {
        this.loadCustomers();
    }

    async loadCustomers() {
        this.customers = await this.service.getAll();
    }

    updateSelectedCustomer(customer: Customer, event: Event) {
        event.preventDefault();
        this.router.navigate(['timeline'])
        window.localStorage.setItem("customer", JSON.stringify(customer));
    }
}
