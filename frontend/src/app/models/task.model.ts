import { Customer } from './customer.model';
import { User } from './user.model';

export class Task {
    id: string;
    description: string;
    instructions: string;
    duration: number;
    creationDate: Date;
    startDate: Date;
    endDate: Date;
    executionDate: Date;
    customer: Customer;
    customerUser: User;
    consultant: User;
    owner: string;

    constructor() {
    }
}
