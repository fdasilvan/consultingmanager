import { Component, OnInit } from '@angular/core';
import { CustomersService } from 'src/app/services/customers/customers.service';
import { CustomerCategory } from 'src/app/models/customercategory.model';
import { CustomerLevel } from 'src/app/models/customerlevel.model';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';
import { Router } from '@angular/router';
import { UserCustomerCategory } from 'src/app/models/usercustomercategory.model';
import { UserCustomerLevel } from 'src/app/models/usercustomerlevel.model';
import { v4 as newGuid } from 'uuid';
import { UserType } from 'src/app/models/usertype.model';

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
  userTypes: UserType[] = [];
  selectedCustomerCategories: CustomerCategory[] = [];
  selectedCustomerLevels: CustomerLevel[] = [];

  async ngOnInit() {
    await this.loadConsultant();

    if (this.consultant) {
      this.isEdit = true;
    } else {
      this.isEdit = false;
      this.consultant = new User();
    }

    await this.loadUserTypes();
    await this.loadCustomerCategories();
    await this.loadCustomerLevels();
  }

  async loadCustomerCategories() {
    this.customerCategories = await this.customerService.getCustomerCategories();
  }

  async loadCustomerLevels() {
    this.customerLevels = await this.customerService.getCustomerLevels();
  }

  async loadUserTypes() {
    this.userTypes = await this.userService.getUserTypes();
  }

  async loadConsultant() {
    if (window.sessionStorage.getItem('consultant') != 'undefined') {
      this.consultant = <User>JSON.parse(window.sessionStorage.getItem('consultant'));
      this.consultant = await this.userService.getUser(this.consultant.id);

      this.consultant.customerCategories = [];
      this.consultant.customerLevels = [];

      this.consultant.userCustomerCategories.forEach(userCustomerCategory => {
        let customerCategory = new CustomerCategory();
        customerCategory.id = userCustomerCategory.customerCategoryId;
      });

      this.consultant.userCustomerCategories.forEach(userCustomerLevel => {
        let customerLevel = new CustomerLevel();
        customerLevel.id = userCustomerLevel.customerCategoryId;
      });
    }
  }

  onCustomerCategoryChange(event: any, customerCategory: CustomerCategory) {
    let checked = event.currentTarget.checked;
    if (checked) {
      let userCustomerCategory = new UserCustomerCategory();
      userCustomerCategory.id = newGuid();
      userCustomerCategory.userid = this.consultant.id;
      userCustomerCategory.customerCategoryId = customerCategory.id;
      this.consultant.userCustomerCategories.push(userCustomerCategory);
    } else {
      this.consultant.userCustomerCategories = this.consultant.userCustomerCategories.filter(o => o.customerCategoryId != customerCategory.id);
    }
  }

  onCustomerLevelChange(event: any, customerLevel: CustomerLevel) {
    let checked = event.currentTarget.checked;
    if (checked) {
      let userCustomerLevel = new UserCustomerLevel();
      userCustomerLevel.id = newGuid();
      userCustomerLevel.userid = this.consultant.id;
      userCustomerLevel.customerLevelId = customerLevel.id;
      this.consultant.userCustomerLevels.push(userCustomerLevel);
    } else {
      this.consultant.userCustomerLevels = this.consultant.userCustomerLevels.filter(o => o.customerLevelId != customerLevel.id);
    }
  }

  isCustomerCategoryChecked(customerCategoryId: string) {
    let result = this.consultant.userCustomerCategories.filter(o => o.customerCategoryId == customerCategoryId);
    return result.length > 0;
  }

  isCustomerLevelChecked(customerLevelId: string) {
    let result = this.consultant.userCustomerLevels.filter(o => o.customerLevelId == customerLevelId);
    return result.length > 0;
  }

  async saveConsultant() {
    await this.userService.saveConsultant(this.consultant);
    if (this.isEdit) {
      alert('Consultor atualizado com sucesso!');
    } else {
      alert('Consultor incluido com sucesso!');
    }
    this.router.navigate(['consultants-list']);
  }

  goBack() {
    window.history.back();
  }
}
