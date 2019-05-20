import { Customer } from './customer.model';
import { User } from './user.model';

export class Task {
    id: string;
    description: string;
    instructions: string;
    duration: number;
    creationDate: Date;
    startDate: Date;
    estimatedEndDate: Date;
    endDate: Date;
    customer: Customer;
    customerUser: User;
    consultant: User;
    owner: User;

    constructor() {
    }
}
