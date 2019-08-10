import { Customer } from './customer.model';

export class CustomerMeeting {
  id: string;
  originalDate: Date;
  date: Date;
  customerId: string;
  customer: Customer;
}
