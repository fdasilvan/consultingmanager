import { Injectable } from '@angular/core';
import { Process } from 'src/app/models/process.model';
import { Task } from 'src/app/models/task.model';
import { Step } from 'src/app/models/step.model';

@Injectable({
    providedIn: 'root'
})
export class TimelineService {

    constructor() { }



    public async getAll(): Promise<Process[]> {

        debugger;

        let stepOnboarding: Step = new Step();

        let tasksList: Task[] = [];

        stepOnboarding.id = "1";
        stepOnboarding.description = "Onboarding";
        stepOnboarding.startDate = new Date(2019, 3, 21);
        stepOnboarding.tasks = tasksList;

        let task1: Task = new Task();
        task1.id = "1";
        task1.duration = 15;
        task1.description = "Disponibilizar na pasta do cliente os arquivos necessários";
        task1.creationDate = new Date(2019, 3, 24);
        task1.estimatedDate = new Date(2019, 3, 26);
        stepOnboarding.tasks.push(task1);

        let task2: Task = new Task();
        task2.id = "2";
        task2.description = "Realizar primeira reunião de apresentação e alinhamento";
        task2.duration = 120;
        task2.creationDate = new Date(2019, 3, 24);
        task2.estimatedDate = new Date(2019, 3, 26);
        stepOnboarding.tasks.push(task2);

        let task3: Task = new Task();
        task3.id = "3";
        task3.description = "Escolher produtos candidatos a estrela";
        task3.duration = 240;
        task3.creationDate = new Date(2019, 3, 24);
        task3.estimatedDate = new Date(2019, 3, 29);
        stepOnboarding.tasks.push(task3);

        let task4: Task = new Task();
        task4.id = "4";
        task4.description = "Analisar a concorrência";
        task4.duration = 300;
        task4.creationDate = new Date(2019, 3, 24);
        task4.estimatedDate = new Date(2019, 3, 30);
        stepOnboarding.tasks.push(task4);

        let task5: Task = new Task();
        task5.id = "5";
        task5.description = "Escolher os 3 pré-produtos estrela";
        task5.duration = 30;
        task5.creationDate = new Date(2019, 3, 24);
        task5.estimatedDate = new Date(2019, 3, 30);
        stepOnboarding.tasks.push(task5);

        let stepWeek1 = new Step();
        stepWeek1.id = "2";
        stepWeek1.description = "Semana 1";
        stepWeek1.startDate = new Date(2019, 4, 1);
        stepWeek1.tasks = [];

        let task6 = new Task();
        task6.id = "6";
        task6.description = "Validar se há mercado";
        task6.duration = 180;
        task6.creationDate = new Date(2019, 3, 24);
        task6.estimatedDate = new Date(2019, 4, 1);
        stepWeek1.tasks.push(task6);

        let task7 = new Task();
        task7.id = "7";
        task7.description = "Diferença entre vender online e offline";
        task7.duration = 30;
        task7.creationDate = new Date(2019, 4, 24);
        task7.estimatedDate = new Date(2019, 4, 1);
        stepWeek1.tasks.push(task7);

        let task8 = new Task();
        task8.id = "8";
        task8.description = "Você não vende para todo mundo";
        task8.duration = 30;
        task8.creationDate = new Date(2019, 4, 24);
        task8.estimatedDate = new Date(2019, 4, 1);
        stepWeek1.tasks.push(task8);

        let task9 = new Task();
        task9.id = "9";
        task9.description = "Você não vende para todo mundo";
        task9.duration = 120;
        task9.creationDate = new Date(2019, 4, 24);
        task9.estimatedDate = new Date(2019, 4, 2);
        stepWeek1.tasks.push(task9);

        let processImplantacao: Process = new Process();

        processImplantacao.id = "1";
        processImplantacao.description = "Implantação";
        processImplantacao.startDate = new Date(2019, 4, 21);
        processImplantacao.steps = [];
        processImplantacao.steps.push(stepOnboarding);
        processImplantacao.steps.push(stepWeek1);

        let processesList: Process[] = [];
        processesList.push(processImplantacao);

        return processesList;
    }
}
