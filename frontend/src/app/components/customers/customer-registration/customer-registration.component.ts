import { Component, OnInit, Input, ElementRef, NgModule } from '@angular/core';
import { Customer } from 'src/app/models/customer.model';
import { Platform } from 'src/app/models/platform.model';
import { CustomersService } from 'src/app/services/customers/customers.service';
import { City } from 'src/app/models/city.model';
import { CustomerCategory } from 'src/app/models/customercategory.model';
import { Plan } from 'src/app/models/plan.model';
import { CustomerSituation } from 'src/app/models/customersituation.model';
import { User } from 'src/app/models/user.model';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/services/user/user.service';
import { CustomerLevel } from 'src/app/models/customerlevel.model';
import { NgxMaskModule } from 'ngx-mask';
import { Team } from 'src/app/models/team.model';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  imports: [NgxMaskModule.forChild()]
})

@Component({
  selector: 'app-customer-registration',
  templateUrl: './customer-registration.component.html',
  styleUrls: ['./customer-registration.component.css']
})
export class CustomerRegistrationComponent implements OnInit {

  constructor(private customersService: CustomersService,
    private userService: UserService,
    private router: Router,
    private route: ActivatedRoute,
    private modalService: NgbModal) { }

  public modalObject: NgbModalRef;
  public customer: Customer;
  public isEdit: boolean = false;
  public citiesList: City[] = [];
  public platformsList: Platform[] = [];
  public categoriesList: CustomerCategory[] = [];
  public plansList: Plan[] = [];
  public situationsList: CustomerSituation[] = [];
  public teamsList: Team[] = [];
  public consultantsList: User[] = [];
  public customerLevelsList: CustomerLevel[] = [];
  public selectedPlan: Plan;

  async ngOnInit() {
    await this.loadCustomer();

    if (this.customer) {
      this.isEdit = true;
      let div = document.getElementById('userInfo');
      div.style.display = 'none';
    }
  }

  async ngAfterViewInit() {
    await this.loadLists();
  }

  async loadCustomer() {
    if (window.sessionStorage.getItem('customer') != 'undefined') {
      this.customer = <Customer>JSON.parse(window.sessionStorage.getItem('customer'));
      this.customer = await this.customersService.getCustomer(this.customer.id);
    }
  }

  openModal(content) {
    this.modalObject = this.modalService.open(content, { size: 'lg', ariaLabelledBy: 'modal-basic-title' });
  }

  goBack() {
    window.history.back();
  }

  async loadLists() {
    this.citiesList = await this.customersService.getCities();
    this.platformsList = await this.customersService.getPlatforms();
    this.categoriesList = await this.customersService.getCustomerCategories();
    this.plansList = await this.customersService.getPlans();
    this.situationsList = await this.customersService.getSituations();
    this.consultantsList = await this.customersService.getConsultants();
    this.customerLevelsList = await this.customersService.getCustomerLevels();
    this.teamsList = await this.customersService.getTeams();
  }

  onPlanChanged(planId: string, txtMeetingsDescription: any) {
    let arr = this.plansList.filter(o => o.id == planId);
    if (arr.length > 0) {
      let plan = arr[0];
      this.selectedPlan = plan;
      txtMeetingsDescription.value = this.selectedPlan.meetingsDescription;
    }
  }

  async addPlatform(platformName: string) {

    if (platformName == '') {
      alert('O nome da plataforme deve ser informado');
      return;
    }

    let platform = new Platform();
    platform.name = platformName;

    await this.customersService.addPlatform(platform);
    this.platformsList = await this.customersService.getPlatforms();
    this.modalObject.close();
  }

  verifyName(txtName, txtStoreUrl) {
    if (txtName.value != '') {
      let regexUrl = /[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)?/gi;
      let url = txtName.value.match(regexUrl);

      if (url && url != '') {
        let result = confirm("Você deseja enviar a URL da Loja para o campo correspondente?");

        if (result) {
          txtName.value = txtName.value.replace(url, '');
          txtStoreUrl.value = url;
        }
      }
    }
  }

  async SaveCustomer(name: string, externalId: string, situationId: any, customerLevelId: any, email: string, phone: string, logoUrl: string,
    storeUrl: string, storeAnalysisUrl: string, cityId: string, platformId: string, categoryId: string, subcategory: string, customerFolderUrl: string,
    meetingsDescription: string, planId: string, teamId: string, consultantId: string, txtUserName: any, txtUserEmail: any, redirectToTimeline: boolean) {

    let customerDto: Customer = new Customer();

    if (name == '') {
      alert('Nome obrigatório!');
      return;
    }

    if (externalId == '') {
      alert('Código do contrato obrigatório!');
      return;
    }

    if (situationId == '') {
      alert('Situação obrigatória!');
      return;
    }

    if (customerLevelId == '') {
      alert('Nível de cliente obrigatório!');
      return;
    }

    if (email == '') {
      alert('E-mail obrigatório!');
      return;
    }

    let match = /^([^\x00-\x20\x22\x28\x29\x2c\x2e\x3a-\x3c\x3e\x40\x5b-\x5d\x7f-\xff]+|\x22([^\x0d\x22\x5c\x80-\xff]|\x5c[\x00-\x7f])*\x22)(\x2e([^\x00-\x20\x22\x28\x29\x2c\x2e\x3a-\x3c\x3e\x40\x5b-\x5d\x7f-\xff]+|\x22([^\x0d\x22\x5c\x80-\xff]|\x5c[\x00-\x7f])*\x22))*\x40([^\x00-\x20\x22\x28\x29\x2c\x2e\x3a-\x3c\x3e\x40\x5b-\x5d\x7f-\xff]+|\x5b([^\x0d\x5b-\x5d\x80-\xff]|\x5c[\x00-\x7f])*\x5d)(\x2e([^\x00-\x20\x22\x28\x29\x2c\x2e\x3a-\x3c\x3e\x40\x5b-\x5d\x7f-\xff]+|\x5b([^\x0d\x5b-\x5d\x80-\xff]|\x5c[\x00-\x7f])*\x5d))*$/.test(email);

    if (!match) {
      alert('E-mail inválido!');
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

    if (teamId == '') {
      alert('Equipe obrigatória!');
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
    customerDto.externalId = externalId;
    customerDto.situationId = situationId;
    customerDto.customerLevelId = customerLevelId;
    customerDto.email = email;
    customerDto.phone = phone;
    customerDto.logoUrl = logoUrl;
    customerDto.storeUrl = storeUrl;
    customerDto.storeAnalysisUrl = storeAnalysisUrl;
    customerDto.cityId = cityId;
    customerDto.platformId = platformId;
    customerDto.categoryId = categoryId;
    customerDto.customerFolderUrl = customerFolderUrl;
    customerDto.meetingsDescription = meetingsDescription;
    customerDto.planId = planId;
    customerDto.teamId = teamId;
    customerDto.consultantId = consultantId;
    customerDto.subcategory = subcategory;

    this.customersService.saveCustomer(customerDto)
      .then(newCustomer => {

        window.sessionStorage.setItem('customer', JSON.stringify(newCustomer));

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
              if (redirectToTimeline) {
                this.router.navigate(['timeline']);
              } else {
                this.router.navigate(['customers']);
              }
            })
            .catch(error => {
              alert('Erro: não foi possível cadastrar o usuário! ' + error.error);
            });
        } else {
          alert('Cliente atualizado com sucesso!');

          if (redirectToTimeline) {
            this.router.navigate(['timeline']);
          } else {
            this.router.navigate(['customers']);
          }
        }
      })
      .catch(error => {
        alert('Erro: não foi possível cadastrar o cliente! ' + error.error);
      });
  }
}
