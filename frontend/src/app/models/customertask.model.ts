import { Customer } from './customer.model';
import { User } from './user.model';
import { TaskType } from './tasktype.model';
import { ModelTask } from './modeltask.model';
import { CustomerStep } from './customerstep.model';

export class CustomerTask {
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
    customerStep: CustomerStep;

    constructor() {
    }
}
