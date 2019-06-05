import { Component, OnInit } from '@angular/core';
import { CustomersService } from '../../services/customers/customers.service';
import { Customer } from 'src/app/models/customer.model';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  constructor(private service: CustomersService,
    private userService: UserService,
    private route: ActivatedRoute,
    private router: Router) { }

  public customers: Customer[];
  public loggedUser: User;

  ngOnInit() {
    this.loggedUser = this.userService.getUser();

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
    window.localStorage.setItem("customer", JSON.stringify(customer));
  }
}
