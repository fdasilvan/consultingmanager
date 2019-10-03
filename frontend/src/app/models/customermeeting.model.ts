import { Customer } from './customer.model';
import { CustomerProcess } from './customerprocess.model';

export class CustomerMeeting {
  id: string;
  originalDate: Date;
  date: Date;
  customerId: string;
  customer: Customer;

  processes: CustomerProcess[];
}
