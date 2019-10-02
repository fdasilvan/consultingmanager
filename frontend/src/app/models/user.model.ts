import { UserType } from './usertype.model';
import { Customer } from './customer.model';
import { CustomerCategory } from './customercategory.model';
import { CustomerLevel } from './customerlevel.model';
import { UserCustomerLevel } from './usercustomerlevel.model';
import { UserCustomerCategory } from './usercustomercategory.model';

export class User {
  id: string;
  name: string;
  email: string;
  password: string;
  userTypeId: string;
  userType: UserType;
  customerId: string;
  conferenceRoomAddress: string;
  availableHoursMonth: number;
  customer: Customer;

  userCustomerCategories: UserCustomerCategory[] = [];
  userCustomerLevels: UserCustomerLevel[] = [];

  customerCategories: CustomerCategory[] = [];
  customerLevels: CustomerLevel[] = [];

  constructor() { }
}
