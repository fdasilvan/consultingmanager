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

  public selectedStep: ModelStep;
  public modelProcess: ModelProcess;
  public isEdit: boolean = false;

  ngOnInit() {
    this.initializeProcess();
    this.loadProcess();
  }

  public loadProcess() {
    if (window.sessionStorage.getItem('modelProcess') != 'undefined') {
      this.isEdit = true;
      this.modelProcess = <ModelProcess>JSON.parse(window.sessionStorage.getItem('modelProcess'));

      if (this.modelProcess.modelSteps.length > 0) {
        this.modelProcess.modelSteps = this.modelProcess.modelSteps.sort((a, b) => -b['description'].localeCompare(a['description']));
        this.selectedStep = this.modelProcess.modelSteps[0];
      }
    }
  }

  initializeProcess() {
    this.modelProcess = new ModelProcess();
    this.modelProcess.id = newGuid();
    this.modelProcess.modelSteps = [];
  }

  public addStep() {
    let modelStep = new ModelStep();

    modelStep.id = newGuid();
    modelStep.description = 'Nova Etapa';
    modelStep.modelTasks = [];

    this.modelProcess.modelSteps.push(modelStep);

    if (this.modelProcess.modelSteps.length == 1) {
      this.selectedStep = this.modelProcess.modelSteps[0];
    }
  }

  public addTask(modelStep: ModelStep) {
    let modelTask = new ModelTask();

    modelTask.id = newGuid();
    modelTask.taskContent = [];

    modelStep.modelTasks.push(modelTask);
  }

  public saveProcess() {
    console.log(this.modelProcess);
  }

  toggleElement(element) {
    element.parentElement.nextElementSibling.style.display = (element.parentElement.nextElementSibling.style.display == 'none' ? '' : 'none');
    element.className = (element.className == 'fa fa-chevron-right' ? 'fa fa-chevron-down' : 'fa fa-chevron-right');
  }

  public selectStep(step: ModelStep) {
    this.selectedStep = step;
  }

  public removeStep(step: ModelStep) {
    this.modelProcess.modelSteps = this.modelProcess.modelSteps.filter(o => o.id != step.id);
  }

  goBack() {
    window.history.back();
  }
}
