import { Platform } from './platform.model';

export class Customer {
    id: string;
    name: string;
    currentProcess: string;
    currentStep: string;
    logoUrl: string;
    platform: Platform;

    constructor() {
    }
}
