import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CustomersService } from 'src/app/services/customers/customers.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Customer } from 'src/app/models/customer.model';

@Component({
  selector: 'app-financial-summary',
  templateUrl: './financial-summary.component.html',
  styleUrls: ['./financial-summary.component.css']
})
export class FinancialSummaryComponent implements OnInit {

  constructor(private router: Router,
    private customersService: CustomersService,
    private modalService: NgbModal) { }

  public customer: Customer;

  ngOnInit() {
    this.loadCustomer();
  }

  loadCustomer() {
    if (window.sessionStorage.getItem('customer') != 'undefined') {
      this.customer = <Customer>JSON.parse(window.sessionStorage.getItem('customer'));
    }
  }
}