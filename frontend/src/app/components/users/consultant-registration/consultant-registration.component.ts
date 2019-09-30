import { Component, OnInit } from '@angular/core';
import { CustomersService } from 'src/app/services/customers/customers.service';
import { CustomerCategory } from 'src/app/models/customercategory.model';
import { CustomerLevel } from 'src/app/models/customerlevel.model';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-consultant-registration',
  templateUrl: './consultant-registration.component.html',
  styleUrls: ['./consultant-registration.component.css']
})
export class ConsultantRegistrationComponent implements OnInit {

  constructor(private userService: UserService,
    private customerService: CustomersService,
    private router: Router) {
    this.loggedUser = this.userService.getLoggedUser();
    if (!this.loggedUser) {
      this.router.navigate(['login']);
    }
  }

  loggedUser: User;
  consultant: User;
  isEdit: boolean;
  customerCategories: CustomerCategory[] = [];
  customerLevels: CustomerLevel[] = [];

  async ngOnInit() {
    await this.loadConsultant();

    if (this.consultant) {
      this.isEdit = true;
    }

    await this.loadCustomerCategories();
    await this.loadCustomerLevels();
  }

  async loadConsultant() {
    if (window.sessionStorage.getItem('consultant') != 'undefined') {
      this.consultant = <User>JSON.parse(window.sessionStorage.getItem('consultant'));
      this.consultant = await this.userService.getUser(this.consultant.id);

      if (!this.consultant.customerCategories) {
        this.consultant.customerCategories = this.customerCategories;
      }

      if (!this.consultant.customerLevels) {
        this.consultant.customerLevels = this.customerLevels;
      }
    }
  }

  async loadCustomerCategories() {
    this.customerCategories = await this.customerService.getCustomerCategories();
  }

  async loadCustomerLevels() {
    this.customerLevels = await this.customerService.getCustomerLevels();
  }

  onCustomerCategoryChange(selectedCustomerCategories: string[]) {
    this.consultant.customerCategories = [];
    selectedCustomerCategories.forEach(customerCategoryId => {
      let customerCategory = new CustomerCategory();
      customerCategory.id = customerCategoryId;
      this.consultant.customerCategories.push(customerCategory);
    });
  }

  onCustomerLevelChange(selectedCustomerLevels: string[]) {
    this.consultant.customerLevels = [];
    selectedCustomerLevels.forEach(customerLevelId => {
      let customerLevel = new CustomerLevel();
      customerLevel.id = customerLevelId;
      this.consultant.customerLevels.push(customerLevel);
    });
  }

  async saveConsultant() {
    if (this.isEdit) {
      console.log(this.consultant);
      this.userService.saveConsultant(this.consultant);
    } else {
      alert('Ainda não implementado!');
    }
  }
}
