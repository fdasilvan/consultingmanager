import { Component, OnInit, Inject } from '@angular/core';
import { CustomersService } from '../../services/customers/customers.service';
import { Customer } from 'src/app/models/customer.model';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { WINDOW } from '@ng-toolkit/universal';

@Component({
    selector: 'app-customers',
    templateUrl: './customers.component.html',
    styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

    constructor(@Inject(WINDOW) private window: Window, private service: CustomersService,
        private route: ActivatedRoute,
        private router: Router) { }
        
    public customers: Customer[];
    public loggedUser: User;
    
    ngOnInit() {
        this.loggedUser = <User>JSON.parse(sessionStorage.getItem('user'));

        if (!this.loggedUser) {
            this.router.navigate(['login']);
        }
        this.loadCustomers();
    }

    async loadCustomers() {
        this.customers = await this.service.getAll();
    }

    updateSelectedCustomer(customer: Customer, event: Event) {
        event.preventDefault();
        this.router.navigate(['timeline'])
        this.window.localStorage.setItem("customer", JSON.stringify(customer));
    }
}
