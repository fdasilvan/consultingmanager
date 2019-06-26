import { Task } from './task.model';
import { CustomerProcess } from './customerprocess.model';

export class Step {
    id: string;
    description: string;
    startDate: Date;
    endDate: Date;
    tasks: Task[];
    customerProcess: CustomerProcess;

    constructor() {
    }
}
