import { Component, OnInit, Input, ElementRef } from '@angular/core';
import { Customer } from 'src/app/models/customer.model';
import { Platform } from 'src/app/models/platform.model';
import { CustomersService } from 'src/app/services/customers/customers.service';
import { City } from 'src/app/models/city.model';
import { CustomerCategory } from 'src/app/models/customercategory.model';
import { Plan } from 'src/app/models/plan.model';
import { CustomerSituation } from 'src/app/models/customersituation.model';
import { User } from 'src/app/models/user.model';
import { Router, ActivatedRoute } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-customer-registration',
  templateUrl: './customer-registration.component.html',
  styleUrls: ['./customer-registration.component.css']
})
export class CustomerRegistrationComponent implements OnInit {

  constructor(private customersService: CustomersService,
    private userService: UserService,
    private router: Router,
    private route: ActivatedRoute) { }

  public customer: Customer;
  public isEdit: boolean = false;
  public citiesList: City[] = [];
  public platformsList: Platform[] = [];
  public categoriesList: CustomerCategory[] = [];
  public plansList: Plan[] = [];
  public situationsList: CustomerSituation[] = [];
  public consultantsList: User[] = [];

  ngOnInit() {
    this.loadCustomer();

    if (this.customer) {
      this.isEdit = true;
      let div = document.getElementById('userInfo');
      div.style.display = 'none';
    }
  }

  ngAfterViewInit() {
    this.loadLists();
  }

  loadCustomer() {
    if (window.sessionStorage.getItem('customer') != 'undefined') {
      this.customer = <Customer>JSON.parse(window.sessionStorage.getItem('customer'));
    }
  }

  goBack() {
    window.history.back();
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
    storeUrl: string, cityId: string, platformId: string, categoryId: string, planId: string, consultantId: string,
    txtUserName: any, txtUserEmail: any) {
    let customerDto: Customer = new Customer();

    if (name == '') {
      alert('Nome obrigatório!');
      return;
    }

    if (situationId == '') {
      alert('Situação obrigatória!');
      return;
    }

    if (email == '') {
      alert('E-mail obrigatório!');
      return;
    }

    if (phone == '') {
      alert('Telefone obrigatório!');
      return;
    }

    if (planId == '') {
      alert('Plano obrigatório!');
      return;
    }

    if (consultantId == '') {
      alert('Consultor responsável obrigatório!');
      return;
    }

    if (!this.isEdit && txtUserName && txtUserName.value == '') {
      alert('Nome do usuário do cliente obrigatório!');
      return;
    }

    if (!this.isEdit && txtUserEmail && txtUserEmail.value == '') {
      alert('E-mail do usuário do cliente obrigatório!');
      return;
    }

    customerDto.id = (this.customer ? this.customer.id : undefined);
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

    this.customersService.saveCustomer(customerDto)
      .then(newCustomer => {
        if (!this.isEdit) {
          let user = new User();

          user.id = undefined;
          user.email = txtUserEmail.value;
          user.name = txtUserName.value;
          user.password = '123456';
          user.userTypeId = '43C2E87C-35A8-47C0-A4DD-D233B836DD4A';
          user.customerId = newCustomer.id;

          this.userService.saveUser(user)
            .then(result => {
              alert('Cliente cadastrado com sucesso!');
              this.router.navigate(['customers']);
            })
            .catch(error => {
              alert('Erro: não foi possível cadastrar o usuário! ' + error.error);
            });
        } else {
          alert('Cliente atualizado com sucesso!');
          this.router.navigate(['customers']);
        }
      })
      .catch(error => {
        alert('Erro: não foi possível cadastrar o cliente! ' + error.error);
      });
  }
}
