import { Component, OnInit, Input } from '@angular/core';
import { Customer } from 'src/app/models/customer.model';
import { Platform } from 'src/app/models/platform.model';
import { CustomersService } from 'src/app/services/customers/customers.service';
import { City } from 'src/app/models/city.model';
import { CustomerCategory } from 'src/app/models/customercategory.model';
import { Plan } from 'src/app/models/plan.model';
import { CustomerSituation } from 'src/app/models/customersituation.model';

@Component({
  selector: 'app-customer-registration',
  templateUrl: './customer-registration.component.html',
  styleUrls: ['./customer-registration.component.css']
})
export class CustomerRegistrationComponent implements OnInit {

  constructor(private customersService: CustomersService) { }

  public citiesList: City[];
  public platformsList: Platform[];
  public categoriesList: CustomerCategory[];
  public plansList: Plan[];
  public situationsList: CustomerSituation[];

  @Input() public customer: Customer;
  ngOnInit() {
    this.loadLists();
  }

  async loadLists() {
    this.citiesList = await this.customersService.getCities();
    this.platformsList = await this.customersService.getPlatforms();
    this.categoriesList = await this.customersService.getCategories();
    this.plansList = await this.customersService.getPlans();
    this.situationsList = await this.customersService.getSituations();
  }
}
