import { Component, OnInit, NgModule } from '@angular/core';
import { Router } from '@angular/router';
import { CustomersService } from 'src/app/services/customers/customers.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Customer } from 'src/app/models/customer.model';
import { FinancialSummaryMonth } from 'src/app/models/financialsummarymonth.model';
import { NgxMaskModule } from 'ngx-mask';

@NgModule({
  imports: [NgxMaskModule.forChild()]
})

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
  public financialMonthsList: FinancialSummaryMonth[] = [];

  ngOnInit() {
    this.loadCustomer();
    this.loadMock();
  }

  loadMock() {
    let september: FinancialSummaryMonth = new FinancialSummaryMonth();
    september.id = '3';
    september.year = 2019;
    september.month = 9;
    september.storeRevenue = 7000;
    september.totalOrders = 70;
    september.paidOrders = 60;
    september.visitors = 7000;
    september.adsInvestment = 2500;

    this.financialMonthsList.push(september);

    let october: FinancialSummaryMonth = new FinancialSummaryMonth();
    october.id = '2';
    october.year = 2019;
    october.month = 10;
    october.storeRevenue = 7000;
    october.totalOrders = 70;
    october.paidOrders = 60;
    october.visitors = 7000;
    october.adsInvestment = 2500;

    this.financialMonthsList.push(october);

    let november: FinancialSummaryMonth = new FinancialSummaryMonth();
    november.id = '1';
    november.year = 2019;
    november.month = 11;
    november.storeRevenue = 10000;
    november.totalOrders = 100;
    november.paidOrders = 80;
    november.visitors = 10000;
    november.adsInvestment = 3000;

    this.financialMonthsList.push(november);
  }

  loadCustomer() {
    if (window.sessionStorage.getItem('customer') != 'undefined') {
      this.customer = <Customer>JSON.parse(window.sessionStorage.getItem('customer'));
    }
  }

  saveForm() {
    alert("Informações salvas com sucesso!");
    console.log(this.financialMonthsList);
  }

  goBack() {
    window.history.back();
  }
}