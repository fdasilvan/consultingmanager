import { CustomerLevel } from './customerlevel.model';
import { CustomerCategory } from './customercategory.model';

export class UserCustomerCategory {

  constructor() { }

  id: string;
  userid: string;
  customerCategoryId: string;
  customerCategory: CustomerCategory;
}
