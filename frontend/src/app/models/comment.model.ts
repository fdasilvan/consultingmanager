import { User } from './user.model';
import { CustomerMeeting } from './customermeeting.model';
import { CustomerTask } from './customertask.model';
import { Customer } from './customer.model';

export class Comment {
  id: string;
  text: string;
  date: Date;

  userId: string;
  user: User;

  customerMeetingId: string;
  customerMeeting: CustomerMeeting;

  customerTaskId: string;
  customerTask: CustomerTask;

  customerId: string;
  customer: Customer;

  constructor() { }
}
