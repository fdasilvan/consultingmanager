import { Component, OnInit } from '@angular/core';
import { CustomersService } from 'src/app/services/customers/customers.service';
import { UserService } from 'src/app/services/user/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Customer } from 'src/app/models/customer.model';
import { CustomerMeeting } from 'src/app/models/customermeeting.model';
import { v4 as newGuid } from 'uuid';
import { MeetingType } from 'src/app/models/meetingtype.model';
import { Contract } from 'src/app/models/contract.model';
import { Plan } from 'src/app/models/plan.model';

@Component({
  selector: 'app-customer-meetings',
  templateUrl: './customer-meetings.component.html',
  styleUrls: ['./customer-meetings.component.css']
})
export class CustomerMeetingsComponent implements OnInit {

  constructor(private router: Router,
    private customersService: CustomersService) { }

  public customer: Customer;
  public selectedContractId: string;
  public contract: Contract;
  public plan: Plan;
  public meetingsList: CustomerMeeting[] = [];
  public meetingTypesList: MeetingType[] = [];
  public showSuggestions: boolean = false;
  public today: Date = new Date();

  async ngOnInit() {
    await this.loadCustomer();
    await this.loadContract();

    if (!this.customer.planId) {
      alert('O cliente não possui um plano cadastrado. Favor atualizar o cadastro do mesmo!');
      this.router.navigate(['customers']);
    } else {
      await this.loadMeetings();
      await this.loadMeetingTypes();
      this.initList();
    }
  }

  async loadCustomer() {
    if (window.sessionStorage.getItem('customer') != 'undefined') {
      this.customer = <Customer>JSON.parse(window.sessionStorage.getItem('customer'));
    }
  }

  async loadContract() {
    if (window.sessionStorage.getItem('contract') != 'undefined') {
      this.selectedContractId = window.sessionStorage.getItem('contract');
      this.contract = await this.customersService.getContract(this.customer.id, this.selectedContractId);
      this.plan = this.contract.plan;
    }
  }

  async loadMeetingTypes() {
    this.meetingTypesList = await this.customersService.getMeetingTypes();
  }

  initList() {
    if (this.meetingsList.length == 0) {
      this.showSuggestions = true;
    }
  }

  async loadMeetings() {
    this.meetingsList = await this.customersService.getMeetings(this.customer.id, this.selectedContractId);
    this.orderMeetings();
  }

  public addMeeting(date: Date, meetingTypeId: string) {
    let customerMeeting = new CustomerMeeting();
    let objDate = (date == null ? this.today : new Date(date));

    customerMeeting.id = newGuid();
    customerMeeting.date = objDate;
    customerMeeting.originalDate = objDate;
    customerMeeting.customerId = this.customer.id;
    customerMeeting.contractId = this.selectedContractId;

    if (meetingTypeId != null) {
      customerMeeting.meetingTypeId = meetingTypeId;
    }

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

    return newDate;
  }

  async suggestMeetings(firstDate: Date) {
    const IMPLANTATION_TYPE_ID = '0a5d9561-6518-47a5-89f3-034f4d0256cd';
    const CONSULTING_TYPE_ID = '38cbb2dd-e1a9-4535-a00a-dcd81cf4fd82';
    const REVIEW_TYPE_ID = 'c203d729-d70a-4bb8-853a-879ef62dabe1';

    if (firstDate) {
      this.meetingsList = [];
      let nextMeetingDate = new Date(firstDate);
      // Needed in order to prevent GMT-3:00 timezone problems
      nextMeetingDate.setDate(nextMeetingDate.getDate() + 1);

      if (!this.plan) {
        alert('Para usar a sugestão de datas de encontros o cliente deve possuir um contrato/plano.');
        return;
      }

      // Implantação
      for (let i = 0; i < this.plan.implantationQuantity; i++) {
        if (i > 0) {
          nextMeetingDate = this.calculateNextMeeting(nextMeetingDate, this.plan.implantationFrequency);
        }
        this.addMeeting(nextMeetingDate, IMPLANTATION_TYPE_ID);
      }

      // Consultoria e Acompanhamento
      if (this.plan.consultingQuantity > 0 && this.plan.reviewQuantity > 0) {
        let meetingsRatio = this.plan.reviewQuantity / this.plan.consultingQuantity;
        meetingsRatio = Math.floor(meetingsRatio);
        if (meetingsRatio < 1) {
          meetingsRatio = 1;
        }

        let reviewCount = 0;

        for (let i = 0; i < this.plan.consultingQuantity; i++) {
          nextMeetingDate = this.calculateNextMeeting(nextMeetingDate, this.plan.consultingFrequency);
          this.addMeeting(nextMeetingDate, CONSULTING_TYPE_ID);

          for (let j = 0; j < meetingsRatio; j++) {
            if (reviewCount >= this.plan.reviewQuantity) {
              continue;
            }
            nextMeetingDate = this.calculateNextMeeting(nextMeetingDate, this.plan.reviewFrequency);
            this.addMeeting(nextMeetingDate, REVIEW_TYPE_ID);
            reviewCount++;
          }
        }
      } else if (this.plan.consultingQuantity > 0) {
        // Somente consultoria
        for (let i = 0; i < this.plan.consultingQuantity; i++) {
          nextMeetingDate = this.calculateNextMeeting(nextMeetingDate, this.plan.consultingFrequency);
          this.addMeeting(nextMeetingDate, CONSULTING_TYPE_ID);
        }
      } else if (this.plan.reviewQuantity > 0) {
        // Somente acompanhamento
        for (let i = 0; i < this.plan.reviewQuantity; i++) {
          nextMeetingDate = this.calculateNextMeeting(nextMeetingDate, this.plan.reviewFrequency);
          this.addMeeting(nextMeetingDate, REVIEW_TYPE_ID);
        }
      } else {
        alert('Não foi possível sugerir os encontros para cliente/contrato. Favor verificar o cadastro do plano.');
      }
    } else {
      alert('Data da primeira reunião inválida.');
    }
  }

  public removeMeeting(meeting: CustomerMeeting) {
    this.meetingsList = this.meetingsList.filter(o => o.id != meeting.id);
  }

  async saveProcess() {
    for (let i = 0; i < this.meetingTypesList.length; i++) {
      let meeting = this.meetingsList[i];
      if (meeting.meetingTypeId == null || meeting.meetingTypeId == '') {
        alert('AVISO! Todos os encontros devem ter um tipo definido.');
        return;
      }
    }

    this.customersService.saveMeetings(this.customer.id, this.meetingsList)
      .then(meetingsList => {
        alert('Encontros salvos com sucesso!');
        window.sessionStorage.setItem('customer', JSON.stringify(this.customer));
        this.router.navigate(['flightplan']);
      })
      .catch(error => {
        alert('Erro: não foi possível cadastrar os encontros do cliente: ' + error.error);
      });
  }

  public dayOfWeek(date: string) {
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
