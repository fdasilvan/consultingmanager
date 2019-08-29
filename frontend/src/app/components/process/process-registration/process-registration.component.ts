import { Component, OnInit } from '@angular/core';
import { ModelProcess } from 'src/app/models/modelprocess.model';
import { ModelStep } from 'src/app/models/modelstep.model';
import { ModelTask } from 'src/app/models/modeltask.model';
import { v4 as newGuid } from 'uuid';
import { ProcessService } from 'src/app/services/process/process.service';
import { Router } from '@angular/router';
import { NgbModalRef, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-process-registration',
  templateUrl: './process-registration.component.html',
  styleUrls: ['./process-registration.component.css']
})
export class ProcessRegistrationComponent implements OnInit {

  constructor(private router: Router,
    private processService: ProcessService,
    private modalService: NgbModal) { }

  public selectedStep: ModelStep;
  public modelProcess: ModelProcess;
  public isEdit: boolean = false;
  public modalObject: NgbModalRef;

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
    modelStep.processId = this.modelProcess.id;

    this.modelProcess.modelSteps.push(modelStep);

    if (this.modelProcess.modelSteps.length == 1) {
      this.selectedStep = this.modelProcess.modelSteps[0];
    }
  }

  public addTask(modelStep: ModelStep) {
    let modelTask = new ModelTask();

    modelTask.id = newGuid();
    modelTask.taskContent = [];
    modelTask.modelStepId = modelStep.id;

    modelStep.modelTasks.push(modelTask);

    this.focusOnTask(modelTask.id);
  }

  public focusOnTask(id: string) {
    var aTags = document.getElementsByTagName("h6");
    var searchText = id;
    var element;

    for (var i = 0; i < aTags.length; i++) {
      let control = aTags[i].textContent.toUpperCase();
      debugger;
      if (control.includes(searchText.toUpperCase())) {
        element = aTags[i];
        break;
      }
    }

    if (element) {
      debugger;
      window.scrollTo(0, parseInt(element));
    }
  }

  public showMailInfo(content) {
    this.modalObject = this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
  }

  validateForm() {
    let elements = document.getElementsByClassName('task-type');
    for (let i = 0; i < elements.length; i++) {
      let element: any = elements[i];
      if (element.value == '') {
        alert('O campo "Tipo Tarefa" deve ser preenchido em todas as atividades!');
        return false;
      }
    }

    return true;
  }

  public saveProcess() {
    if (this.validateForm()) {
      console.log('Form VÁLIDO!');
      console.log(this.modelProcess);
      debugger;
      this.processService.saveProcess(this.modelProcess);
      alert('Processo salvo com sucesso!');
      this.router.navigate(['processes']);
    } else {
      console.log('Form INVÁLIDO!');
    }
  }

  toggleElement(element) {
    element.parentElement.nextElementSibling.style.display = (element.parentElement.nextElementSibling.style.display == 'none' ? '' : 'none');
    element.className = (element.className == 'fa fa-chevron-right' ? 'fa fa-chevron-down' : 'fa fa-chevron-right');
  }

  public selectStep(step: ModelStep) {
    if (this.validateForm()) {
      this.selectedStep = step;
    }
  }

  public removeStep(step: ModelStep) {
    this.modelProcess.modelSteps = this.modelProcess.modelSteps.filter(o => o.id != step.id);
  }

  public removeTask(task: ModelTask) {
    this.selectedStep.modelTasks = this.selectedStep.modelTasks.filter(o => o.id != task.id);
  }

  goBack() {
    window.history.back();
  }
}
