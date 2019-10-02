import { CustomerLevel } from './customerlevel.model';
import { CustomerCategory } from './customercategory.model';

export class UserCustomerCategory {

  constructor() { }

  userid: string;
  customerCategoryId: string;
  customerCategory: CustomerCategory;
}
