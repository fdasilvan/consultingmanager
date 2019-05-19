import { Injectable } from '@angular/core';
import { Task } from 'src/app/models/task.model';
import { Step } from 'src/app/models/step.model';
import { Process } from 'src/app/models/process.model';

@Injectable({
    providedIn: 'root'
})
export class WorklistService {

    constructor() { }

    public async getAll(): Promise<Process[]> {
        let stepOnboarding: Step = new Step();

        let tasksList: Task[] = [];

        stepOnboarding.id = "1";
        stepOnboarding.description = "Onboarding";
        stepOnboarding.startDate = new Date(2019, 3, 21);
        stepOnboarding.tasks = tasksList;

        let task1: Task = new Task();
        task1.id = "1";
        task1.duration = 120;
        task1.description = "Disponibilizar na pasta do cliente os arquivos necessários";
        task1.creationDate = new Date(2019, 3, 24);
        task1.startDate = new Date(2019, 3, 26);
        task1.endDate = new Date(2019, 3, 26);
        task1.estimatedEndDate = new Date(2019, 3, 27);
        stepOnboarding.tasks.push(task1);

        let task2: Task = new Task();
        task2.id = "2";
        task2.description = "Realizar primeira reunião de apresentação e alinhamento";
        task2.duration = 120;        
        task2.creationDate = new Date(2019, 3, 24);
        task2.startDate = new Date(2019, 3, 26);
        task2.endDate = new Date(2019, 3, 26);
        stepOnboarding.tasks.push(task2);

        let task3: Task = new Task();
        task3.id = "3";
        task3.description = "Escolher produtos candidatos a estrela";
        task3.duration = 240;        
        task3.creationDate = new Date(2019, 3, 24);
        task3.startDate = new Date(2019, 3, 26);
        task3.endDate = new Date(2019, 3, 29);
        stepOnboarding.tasks.push(task3);

        let task4: Task = new Task();
        task4.id = "4";
        task4.description = "Analisar a concorrência";
        task4.duration = 240;        
        task4.creationDate = new Date(2019, 3, 24);
        task4.startDate = new Date(2019, 3, 29);
        task4.endDate = new Date(2019, 3, 30);
        stepOnboarding.tasks.push(task4);

        let processImplantacao: Process = new Process();

        processImplantacao.id = "1";
        processImplantacao.description = "Implantação";
        processImplantacao.startDate = new Date(2019, 3, 21);
        processImplantacao.customerSteps = [];
        processImplantacao.customerSteps.push(stepOnboarding);

        let processesList: Process[] = [];
        processesList.push(processImplantacao);
        
        return processesList;
    }
}
