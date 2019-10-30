import { Component, OnInit } from '@angular/core';
import { Contract } from 'src/app/models/contract.model';
import { Customer } from 'src/app/models/customer.model';
import { Router } from '@angular/router';
import { CustomersService } from 'src/app/services/customers/customers.service';
import { ContractSituation } from 'src/app/models/contractsituation.model';
import { Plan } from 'src/app/models/plan.model';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-customer-contracts',
  templateUrl: './customer-contracts.component.html',
  styleUrls: ['./customer-contracts.component.css']
})
export class CustomerContractsComponent implements OnInit {

  constructor(private router: Router,
    private customersService: CustomersService,
    private modalService: NgbModal) { }

  public customerContractsList: Contract[] = [];
  public plansList: Plan[] = [];
  public contractSituationsList: ContractSituation[] = [];
  public customer: Customer;
  public selectedContract: Contract;
  public modalObject: NgbModalRef;

  ngOnInit() {
    this.loadCustomer();

    if (!this.customer.planId) {
      alert('O cliente não possui um plano cadastrado. Favor atualizar o cadastro do mesmo!');
      this.router.navigate(['customers']);
    } else {
      this.loadContracts();
      this.loadPlans();
      this.loadContractSituations();
    }
  }

  loadCustomer() {
    if (window.sessionStorage.getItem('customer') != 'undefined') {
      this.customer = <Customer>JSON.parse(window.sessionStorage.getItem('customer'));
    }
  }

  async loadContracts() {
    this.customerContractsList = await this.customersService.getContracts(this.customer.id);
  }

  async loadPlans() {
    this.plansList = await this.customersService.getPlans();
  }

  async loadContractSituations() {
    this.contractSituationsList = await this.customersService.getContractSituations();
  }

  addContract(content) {
    this.selectedContract = new Contract();
    this.selectedContract.customerId = this.customer.id;
    this.openModal(content);
  }

  onContractSelected(contract: Contract, content) {
    this.selectedContract = contract;
    this.openModal(content);
  }

  async saveContract() {

    if (this.selectedContract.number == '') {
      alert('Número do contrato é obrigatório!');
      return;
    }

    if (this.selectedContract.planId == '') {
      alert('Plano é obrigatório!');
      return;
    }

    if (this.selectedContract.contractSituationId == '') {
      alert('Situação do contrato é obrigatória!');
      return;
    }

    if (this.selectedContract.startDate == null || this.selectedContract.endDate == null) {
      alert('Vigência do contrato obrigatória!');
      return;
    }

    let success = await this.customersService.saveContract(this.customer.id, this.selectedContract);

    if (success) {
      alert('Contrato cadastrado com sucesso!');
      this.modalObject.close();
    } else {
      alert('Houve um problema ao cadastrar o contrato.');
    }

    this.loadContracts();
  }

  public openModal(content) {
    this.modalObject = this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
  }

  goBack() {
    window.history.back();
  }
}
