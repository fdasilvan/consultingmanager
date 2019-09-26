import { User } from './user.model';
import { Customer } from './customer.model';

export class DashboardsTasks {

  constructor() { }

  consultantId: string;
  consultant: User;
  notStartedTasks: number;
  dueTasks: number;
  onTimeTasks: number;
}
