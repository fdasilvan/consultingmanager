import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CustomersService } from 'src/app/services/customers/customers.service';
import { Customer } from 'src/app/models/customer.model';
import { CustomerMeeting } from 'src/app/models/customermeeting.model';
import { CustomerProcess } from 'src/app/models/customerprocess.model';

@Component({
  selector: 'app-flightplan',
  templateUrl: './flightplan.component.html',
  styleUrls: ['./flightplan.component.css']
})
export class FlightplanComponent implements OnInit {

  constructor(private router: Router,
    private customersService: CustomersService) { }

  public customer: Customer;
  public meetings: CustomerMeeting[] = [];
  public processes: CustomerProcess[] = []
  public selectedMeeting: CustomerMeeting;
  

  ngOnInit() {
    this.loadCustomer();
    this.loadMeetings();
  }

  loadCustomer() {
    if (window.sessionStorage.getItem('customer') != 'undefined') {
      this.customer = <Customer>JSON.parse(window.sessionStorage.getItem('customer'));
    }
  }

  async loadMeetings() {
    this.meetings = await this.customersService.getMeetings(this.customer.id);

    if (this.meetings.length > 0) {
      this.selectedMeeting = this.meetings[0];
    }
  }

  selectMeeting(meeting: CustomerMeeting) {
    this.selectedMeeting = meeting;
  }
}
