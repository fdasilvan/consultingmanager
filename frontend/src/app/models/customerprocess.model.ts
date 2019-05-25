import { Step } from './step.model';

export class CustomerProcess {
    id: string;
    description: string;
    startDate: Date;
    estimateEndDate: Date;
    endDate: Date;
    customerSteps: Step[];

    constructor() {
    }
}
