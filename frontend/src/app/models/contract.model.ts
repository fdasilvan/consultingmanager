import { Customer } from './customer.model';
import { Plan } from './plan.model';
import { ContractSituation } from './contractsituation.model';

export class Contract {
  id: string;
  startDate: Date;
  endDate: Date;
  number: string;

  customerId: string;
  customer: Customer;

  planId: string;
  plan: Plan;

  contractSituationId: string;  
  contractSituation: ContractSituation;

  constructor() {
  }
}
