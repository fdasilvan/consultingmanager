import { ModelTask } from './modeltask.model';

export class ModelStep {
    id: string;
    description: string;
    processId: string;
    modelTasks: ModelTask[];

    constructor() {
    }
}
