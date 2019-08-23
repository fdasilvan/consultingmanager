import { UserType } from './usertype.model';
import { Customer } from './customer.model';

export class User {
  id: string;
  name: string;
  email: string;
  password: string;
  userTypeId: string;
  userType: UserType;
  customerId: string;
  conferenceRoomAddress: string;
  customer: Customer;

  constructor() {
  }
}
