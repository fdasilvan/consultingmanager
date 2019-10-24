import { Component, OnInit, Input, ViewChild, TemplateRef, NgModule } from '@angular/core';
import { CustomersService } from '../services/customers/customers.service';
import { UserService } from '../services/user/user.service';
import { Router } from '@angular/router';
import { User } from '../models/user.model';
import { Contact } from '../models/contact.model';
import { NgxMaskModule } from 'ngx-mask';

@NgModule({
  imports: [NgxMaskModule.forChild()]
})

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {
  @Input() customerId: string;
  @ViewChild('newContactForm')
  public newContactFormTemplate: TemplateRef<any>;

  @ViewChild('addContactCard')
  public addContactCardTemplate: TemplateRef<any>;

  @ViewChild('editContactForm')
  public editContactForm: TemplateRef<any>;

  public loggedUser: User;
  public contacts: Contact[];
  public currentContact: Contact;
  public template: TemplateRef<any>

  constructor(
    private customerService: CustomersService,
    private userService: UserService,
    private router: Router) {

    this.loggedUser = this.userService.getLoggedUser();

    if (!this.loggedUser) {
      this.router.navigate(['login']);
    }
  }

  ngOnInit() {
    this.currentContact = null;
    this.loadContacts(this.customerId);
    this.template = this.addContactCardTemplate;
  }

  async loadContacts(customerId: string) {
    this.contacts = await this.customerService.getContacts(customerId);
  }

  addContactForm(contact: Contact, event: any) {
    if(contact) {
      let container:HTMLElement = event.target.closest('.contact-card');
      container.getElementsByClassName('display-contact-card')[0].classList.toggle("d-none");
      container.getElementsByClassName('edit-contact-card')[0].classList.remove("d-none");
    } else {
      this.template = this.newContactFormTemplate;
    }
  }

  async SaveContact(name: string, role: string, phone: string, email: string, id: string) {
    console.log(name, role, email, phone);
    name = name.trim();
    role = role.trim();
    email = email.trim();

    let contactDto: Contact = new Contact();

    if (name == '') {
      alert('Nome obrigatório!');
      return;
    }

    if (role == '') {
      alert('Função obrigatória!');
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


    contactDto.id = id;
    contactDto.name = name;
    contactDto.email = email;
    contactDto.phone = phone;
    contactDto.role = role;
    contactDto.customerId = this.customerId;

    await this.customerService.saveContacts(this.customerId, [contactDto])
      .then(newContact => {
        this.ngOnInit();
      })
      .catch(error => {
        alert('Erro: não foi possível cadastrar o contato! ' + error.error);
        console.log(error.error)
        this.ngOnInit();
      });
  }
}
