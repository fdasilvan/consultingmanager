import { Component, OnInit } from '@angular/core';
import { ModelProcess } from 'src/app/models/modelprocess.model';
import { ModelStep } from 'src/app/models/modelstep.model';
import { ModelTask } from 'src/app/models/modeltask.model';
import { v4 as newGuid } from 'uuid';

@Component({
  selector: 'app-process-registration',
  templateUrl: './process-registration.component.html',
  styleUrls: ['./process-registration.component.css']
})
export class ProcessRegistrationComponent implements OnInit {

  constructor() { }

  public modelProcess: ModelProcess;

  ngOnInit() {
    this.initializeProcess();
  }

  initializeProcess() {
    this.modelProcess = new ModelProcess();
    this.modelProcess.id = newGuid();
    this.modelProcess.modelSteps = [];
  }

  public addStep() {
    let modelStep = new ModelStep();
    
    modelStep.id = newGuid();
    modelStep.description = '';
    modelStep.modelTasks = [];

    this.modelProcess.modelSteps.push(modelStep);    
  }

  public addTask(modelStep: ModelStep) {
    let modelTask = new ModelTask();
    
    modelTask.id = newGuid();
    modelTask.taskContent = [];

    modelStep.modelTasks.push(modelTask);
  }

  public testObject() {
    console.log(this.modelProcess);
  }
}
