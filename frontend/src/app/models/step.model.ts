import { Task } from './task.model';

export class Step {
    id: string;
    description: string;
    startDate: Date;
    endDate: Date;
    tasks: Task[];

    constructor() {
    }
}
