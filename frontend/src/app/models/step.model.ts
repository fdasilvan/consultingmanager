import { Task } from './task.model';

export class Step {
    id: string;
    description: string;
    startDate: Date;
    tasks: Task[];

    constructor() {
    }
}
