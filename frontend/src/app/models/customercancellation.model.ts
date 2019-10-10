import { Customer } from './customer.model';
import { CancellationReason } from './cancellationreason.model';
import { User } from './user.model';

export class CustomerCancellation {
  id: string;
  date: Date;
  notes: string;

  customerId: string;
  customer: Customer;

  cancellationReasonId: string;
  cancellationReason: CancellationReason;

  userId: string;
  user: User;
}
