import { Component, OnInit } from '@angular/core';
import { CustomersService } from 'src/app/services/customers/customers.service';
import { UserService } from 'src/app/services/user/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Customer } from 'src/app/models/customer.model';
import { CustomerMeeting } from 'src/app/models/customermeeting.model';
import { v4 as newGuid } from 'uuid';
import { CommonService } from 'src/app/services/common/common.service';

@Component({
  selector: 'app-customer-meetings',
  templateUrl: './customer-meetings.component.html',
  styleUrls: ['./customer-meetings.component.css']
})
export class CustomerMeetingsComponent implements OnInit {

  constructor(private router: Router,
    private customersService: CustomersService) { }

  public customer: Customer;
  public meetingsList: CustomerMeeting[] = [];
  public showSuggestions: boolean = false;

  ngOnInit() {
    this.loadCustomer();

    if (!this.customer.planId) {
      alert('O cliente não possui um plano cadastrado. Favor atualizar o cadastro do mesmo!');
      this.router.navigate(['customers']);
    } else {
      this.loadMeetings();
      this.initList();
    }
  }

  loadCustomer() {
    if (window.sessionStorage.getItem('customer') != 'undefined') {
      this.customer = <Customer>JSON.parse(window.sessionStorage.getItem('customer'));
    }
  }

  initList() {
    if (this.meetingsList.length == 0) {
      this.showSuggestions = true;
    }
  }

  async loadMeetings() {
    this.meetingsList = await this.customersService.getMeetings(this.customer.id);
    this.orderMeetings();
  }

  public addMeeting() {
    let customerMeeting = new CustomerMeeting();

    customerMeeting.id = newGuid();
    customerMeeting.date = new Date();
    customerMeeting.originalDate = new Date();
    customerMeeting.customerId = this.customer.id;

    this.meetingsList.push(customerMeeting);
  }

  public calculateNextMeeting(date: Date, days: number) {
    let newDate = date;

    newDate.setDate(newDate.getDate() + days);
    let weekday = newDate.getDay();

    if (weekday == 0) {
      newDate.setDate(newDate.getDate() + 1);
    }

    if (weekday == 6) {
      newDate.setDate(newDate.getDate() + 2);
    }

    let newMeetingObj = new CustomerMeeting();

    newMeetingObj.id = newGuid();
    newMeetingObj.customerId = this.customer.id;
    newMeetingObj.date = new Date(newDate.getTime());
    newMeetingObj.originalDate = new Date(newDate.getTime());

    this.meetingsList.push(newMeetingObj);

    return newDate;
  }

  public suggestMeetings(qtyMeetings: number) {
    this.meetingsList = [];
    let today = new Date();

    let endDate = new Date();
    endDate.setMonth(endDate.getMonth() + this.customer.plan.duration);

    const diffTime = Math.abs(endDate.getTime() - today.getTime());
    const diffDays = Math.floor(diffTime / (1000 * 60 * 60 * 24));
    const daysBetweenMeetings = Math.floor(diffDays / qtyMeetings);

    let lastMeeting = today;

    for (let i = 1; i < qtyMeetings; i++) {
      if (i == 1) {
        lastMeeting = this.calculateNextMeeting(lastMeeting, 1);
      }
      lastMeeting = this.calculateNextMeeting(lastMeeting, daysBetweenMeetings);
    }
  }

  public removeMeeting(meeting: CustomerMeeting) {
    this.meetingsList = this.meetingsList.filter(o => o.id != meeting.id);
  }

  public saveProcess() {
    this.customersService.saveMeetings(this.customer.id, this.meetingsList)
      .then(meetingsList => {
        console.log(meetingsList);
        alert('Encontros salvos com sucesso!');
        this.router.navigate(['customers']);
      })
      .catch(error => {
        alert('Erro: não foi possível cadastrar os encontros do cliente: ' + error.error);
      });
  }

  public dayOfWeek(date: string) {
    debugger;
    if (date) {
      let dateType = new Date(date);
      let weekday = dateType.getDay();
      switch (weekday) {
        case 0:
          return 'Domingo';
        case 1:
          return 'Segunda-feira';
        case 2:
          return 'Terça-feira';
        case 3:
          return 'Quarta-feira';
        case 4:
          return 'Quinta-feira';
        case 5:
          return 'Sexta-feira';
        case 6:
          return 'Sábado';
      }
    }
  }

  public orderMeetings() {
    this.meetingsList = this.meetingsList.sort((a, b) => new Date(a.date).getTime() - new Date(b.date).getTime());
  }

  goBack() {
    window.history.back();
  }
}
