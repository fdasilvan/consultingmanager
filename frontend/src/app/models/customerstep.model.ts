import { CustomerProcess } from './customerprocess.model';
import { CustomerTask } from './customertask.model';

export class CustomerStep {
  id: string;
  description: string;
  startDate: Date;
  endDate: Date;
  customerTasks: CustomerTask[];
  customerProcess: CustomerProcess;

  constructor() {
  }
}
