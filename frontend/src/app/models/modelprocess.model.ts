import { ModelStep } from './modelstep.model';

export class ModelProcess {
  id: string;
  description: string;
  modelSteps: ModelStep[];
  enabled: boolean;

  constructor() {
  }
}
