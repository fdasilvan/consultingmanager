import { TaskContent } from './taskcontent.model';

export class ModelTask {
    id: string;
    description: string;
    instructions: string;
    duration: number;
    startAfterDays: number;
    dueDays: number;
    taskContent: TaskContent[];

    constructor() {
    }
}
