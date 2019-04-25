import { Customer } from './customer.model';
import { User } from './user.model';

export class Task {
    id: string;
    description: string;
    duration: number;
    creationDate: Date;
    estimatedDate: Date;
    executionDate: Date;
    customer: Customer;
    customerUser: User;
    consultingUser: User;

    constructor() {
    }
}
