import { TaskContent } from './taskcontent.model';
import { TaskType } from './tasktype.model';

export class ModelTask {
  id: string;
  description: string;
  instructions: string;
  duration: number;
  startAfterDays: number;
  dueDays: number;
  taskTypeId: string;
  taskType: TaskType;
  modelStepId: string;
  mailSubject: string;
  mailBody: string;
  taskContent: TaskContent[];
  enabled: boolean;

  constructor() {
  }
}
