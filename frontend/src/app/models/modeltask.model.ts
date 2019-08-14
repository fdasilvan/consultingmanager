import { TaskContent } from './taskcontent.model';

export class ModelTask {
    id: string;
    description: string;
    instructions: string;
    duration: number;
    startAfterDays: number;
    dueDays: number;
    taskTypeId: string;
    modelStepId: string;
    taskContent: TaskContent[];

    constructor() {
    }
}
