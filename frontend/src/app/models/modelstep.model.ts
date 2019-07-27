import { ModelTask } from './modeltask.model';

export class ModelStep {
    id: string;
    description: string;
    modelTasks: ModelTask[];

    constructor() {
    }
}
