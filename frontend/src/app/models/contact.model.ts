import { Customer } from './customer.model';

export class Contact {
  id: string;
  name: string;
  email: string;
  phone: string;
  role: string;
  customerId: string;
  customer: Customer;

  constructor() {
  }
}
