import { CustomerStep } from './customerstep.model';

export class CustomerProcess {
  id: string;
  description: string;
  startDate: Date;
  estimateEndDate: Date;
  endDate: Date;
  detail: string;
  customerMeetingId: string;
  customerSteps: CustomerStep[];

  constructor() {
  }
}
