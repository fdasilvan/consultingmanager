import { Platform } from './platform.model';
import { User } from './user.model';
import { City } from './city.model';
import { CustomerCategory } from './customercategory.model';
import { Plan } from './plan.model';
import { CustomerSituation } from './customersituation.model';

export class Customer {
    id: string;
    createdDate: Date;
    name: string;
    logoUrl: string;
    storeUrl: string;
    phone: string;    
    email: string;    
    
    consultant: User;
    city: City;
    platform: Platform;
    category: CustomerCategory;
    plan: Plan;
    sitaution: CustomerSituation;

    constructor() {
    }
}
