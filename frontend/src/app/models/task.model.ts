import { Customer } from './customer.model';
import { User } from './user.model';
import { TaskType } from './tasktype.model';

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
    taskType: TaskType;

    customerProcessDescription: string;
    customerStepDescription: string;

    constructor() {
    }
}
