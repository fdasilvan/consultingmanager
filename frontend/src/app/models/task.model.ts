import { Customer } from './customer.model';
import { User } from './user.model';
import { TaskType } from './tasktype.model';
import { ModelTask } from './modeltask.model';

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
    modelTask: ModelTask;

    constructor() {
    }
}
