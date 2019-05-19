import { Step } from './step.model';

export class Process {
    id: string;
    description: string;
    startDate: Date;
    estimateEndDate: Date;
    endDate: Date;
    customerSteps: Step[];

    constructor() {
    }
}
