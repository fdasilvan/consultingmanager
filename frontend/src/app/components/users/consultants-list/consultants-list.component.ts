import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user/user.service';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { CustomersService } from 'src/app/services/customers/customers.service';

@Component({
  selector: 'app-consultants-list',
  templateUrl: './consultants-list.component.html',
  styleUrls: ['./consultants-list.component.css']
})
export class ConsultantsListComponent implements OnInit {

  constructor(private userService: UserService,
    private customerService: CustomersService,
    private router: Router) { }

  public consultantsList: User[] = [];
  public loggedUser: User;

  ngOnInit() {
    this.loggedUser = this.userService.getLoggedUser();
    if (!this.loggedUser) {
      this.router.navigate(['login']);
    }

    this.loadConsultants();
  }

  async loadConsultants() {
    this.consultantsList = await this.customerService.getConsultants();
  }

  selectConsultant(consultant) {
    window.sessionStorage.setItem('consultant', JSON.stringify(consultant));
    this.router.navigate(['consultant-registration']);
  }
}
