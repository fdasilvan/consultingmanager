import { Component, OnInit, Input } from '@angular/core';
import { Customer } from 'src/app/models/customer.model';
import { Platform } from 'src/app/models/platform.model';
import { CustomersService } from 'src/app/services/customers/customers.service';
import { City } from 'src/app/models/city.model';
import { CustomerCategory } from 'src/app/models/customercategory.model';
import { Plan } from 'src/app/models/plan.model';
import { CustomerSituation } from 'src/app/models/customersituation.model';
import { User } from 'src/app/models/user.model';

@Component({
  selector: 'app-customer-registration',
  templateUrl: './customer-registration.component.html',
  styleUrls: ['./customer-registration.component.css']
})
export class CustomerRegistrationComponent implements OnInit {

  constructor(private customersService: CustomersService) { }

  public isEdit: boolean = false;
  public citiesList: City[];
  public platformsList: Platform[];
  public categoriesList: CustomerCategory[];
  public plansList: Plan[];
  public situationsList: CustomerSituation[];
  public consultantsList: User[];

  @Input() public customer: Customer;
  ngOnInit() {
    debugger;
    if (this.customer) {
      this.isEdit = true;
    }
    this.loadLists();
  }

  async loadLists() {
    this.citiesList = await this.customersService.getCities();
    this.platformsList = await this.customersService.getPlatforms();
    this.categoriesList = await this.customersService.getCategories();
    this.plansList = await this.customersService.getPlans();
    this.situationsList = await this.customersService.getSituations();
    this.consultantsList = await this.customersService.getConsultants();
  }

  async SaveCustomer(name: string, situationId: any, email: string, phone: string, logoUrl: string,
    storeUrl: string, cityId: string, platformId: string, categoryId: string, planId: string, consultantId: string) {

    debugger;

    let customerDto: Customer = new Customer();

    customerDto.id = (this.customer ? this.customer.id : null);
    customerDto.name = name;
    customerDto.situationId = situationId;
    customerDto.email = email;
    customerDto.phone = phone;
    customerDto.logoUrl = logoUrl;
    customerDto.storeUrl = storeUrl;
    customerDto.cityId = cityId;
    customerDto.platformId = platformId;
    customerDto.categoryId = categoryId;
    customerDto.planId = planId;
    customerDto.consultantId = consultantId;

    await this.customersService.SaveCustomer(customerDto);
  }
}
