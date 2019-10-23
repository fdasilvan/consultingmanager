import { Customer } from './customer.model';

export class CustomerContact {
  id: string;
  name: string;
  email: string;
  phone: string;
  role: string;
  customerId: string;
  customer: Customer;
}
