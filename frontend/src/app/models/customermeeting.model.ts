import { Customer } from './customer.model';
import { CustomerProcess } from './customerprocess.model';
import { Contract } from './contract.model';
import { MeetingType } from './meetingtype.model';

export class CustomerMeeting {
  id: string;
  originalDate: Date;
  date: Date;
  isFinished: boolean;
  customerId: string;
  customer: Customer;
  contractId: string;
  contract: Contract;
  meetingTypeId: string;
  meetingType: MeetingType;

  processes: CustomerProcess[];
}
