import { Component, OnInit } from '@angular/core';
import { CustomersService } from '../../../services/customers/customers.service';
import { Customer } from 'src/app/models/customer.model';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { CustomerSituation } from 'src/app/models/customersituation.model';
import { Plan } from 'src/app/models/plan.model';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersListComponent implements OnInit {

  constructor(private service: CustomersService,
    private userService: UserService,
    private router: Router) { }

  public customers: Customer[] = [];
  public filteredCustomers: Customer[] = [];
  public consultantsList: User[] = [];
  public situationsList: CustomerSituation[] = [];
  public plansList: Plan[] = [];
  public loggedUser: User;
  public modalObject: NgbModalRef;

  public canAddCustomer: boolean = false;
  public filterConsultant: boolean = false;

  async ngOnInit() {
    this.loggedUser = this.userService.getUser();

    if (!this.loggedUser) {
      this.router.navigate(['login']);
    }

    this.canAddCustomer = (this.loggedUser.userType.description == 'Administrador' || this.loggedUser.userType.description == 'Líder');

    this.loadFilters();
    await this.loadCustomers();
    if (this.filterConsultant) {
      this.filterResults(this.loggedUser.id, '', '', '');
    }
  }

  async loadCustomers() {
    this.customers = await this.service.getAll();
    this.filteredCustomers = this.customers;
  }

  goToCustomerTimeline(customer: Customer, event: Event) {
    event.preventDefault();
    this.router.navigate(['timeline'])
    window.sessionStorage.setItem('customer', JSON.stringify(customer));
  }

  customerRegistration(customer) {
    window.sessionStorage.setItem('customer', JSON.stringify(customer));
    this.router.navigate(['customer-registration']);
  }

  customerMeetings(customer) {
    window.sessionStorage.setItem('customer', JSON.stringify(customer));
    this.router.navigate(['customer-meetings']);
  }

  customerFlightplan(customer) {
    window.sessionStorage.setItem('customer', JSON.stringify(customer));
    this.router.navigate(['flightplan']);
  }

  async loadConsultantsList() {
    this.consultantsList = await this.service.getConsultants();

    if (this.consultantsList.find(o => o.id == this.loggedUser.id)) {
      this.filterConsultant = true;
    }
  }

  async loadPlansList() {
    this.plansList = await this.service.getPlans();
  }

  async loadSituationsList() {
    this.situationsList = await this.service.getSituations();
  }

  loadFilters() {
    this.loadConsultantsList();
    this.loadSituationsList();
    this.loadPlansList();
  }

  filterResults(consultantId: string, customerName: string, situationId: string, planId: string) {
    this.filteredCustomers = this.customers;

    if (consultantId != '') {
      this.filteredCustomers = this.filteredCustomers.filter(customer => {
        return customer.consultant && customer.consultant.id == consultantId;
      });
    }

    if (customerName != '') {
      this.filteredCustomers = this.filteredCustomers.filter(customer => {
        return customer && customer.name.toUpperCase().includes(customerName.toUpperCase());
      });
    }

    if (situationId != '') {
      this.filteredCustomers = this.filteredCustomers.filter(customer => {
        return customer && customer.situationId == situationId;
      });
    }

    if (planId != '') {
      this.filteredCustomers = this.filteredCustomers.filter(customer => {
        return customer && customer.planId == planId;
      });
    }
  }

  clearFilters(lstConsultant, txtCustomer, lstSituation, lstPlan) {
    lstConsultant.selectedIndex = 0;
    txtCustomer.value = '';
    lstSituation.selectedIndex = 0;
    lstPlan.selectedIndex = 0;
    this.filteredCustomers = this.customers;
  }
}
