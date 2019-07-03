import { Platform } from './platform.model';
import { User } from './user.model';

export class Customer {
    id: string;
    createdDate: Date;
    name: string;
    logoUrl: string;
    storeUrl: string;
    phone: string;    
    email: string;    
    
    consultant: User;
    platform: Platform;

    constructor() {
    }
}
