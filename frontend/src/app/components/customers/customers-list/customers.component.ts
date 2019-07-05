import { Component, OnInit } from '@angular/core';
import { CustomersService } from '../../../services/customers/customers.service';
import { Customer } from 'src/app/models/customer.model';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { CustomerRegistrationComponent } from 'src/app/components/customers/customer-registration/customer-registration.component';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersListComponent implements OnInit {

  constructor(private service: CustomersService,
    private userService: UserService,
    private modalService: NgbModal,
    private route: ActivatedRoute,
    private router: Router) { }

  public customers: Customer[];
  public loggedUser: User;
  public customersCount: number = 0;
  public modalObject: NgbModalRef;
  public canAddCustomer: boolean = false;

  ngOnInit() {
    this.loggedUser = this.userService.getUser();

    if (!this.loggedUser) {
      this.router.navigate(['login']);
    }
    this.loadCustomers();

    this.canAddCustomer = (this.loggedUser.userType.description == 'Administrador' || this.loggedUser.userType.description == 'Líder');
  }

  async loadCustomers() {
    this.customers = await this.service.getAll();
    this.customersCount = this.customers.length;
  }

  goToCustomerTimeline(customer: Customer, event: Event) {
    event.preventDefault();
    this.router.navigate(['timeline'])
    window.localStorage.setItem("customer", JSON.stringify(customer));
  }

  openCustomerModal(customer) {
    debugger;
    this.modalObject = this.modalService.open(CustomerRegistrationComponent, { ariaLabelledBy: 'modal-basic-title', size: 'lg' });
    this.modalObject.componentInstance.customer = customer;
  }
}
