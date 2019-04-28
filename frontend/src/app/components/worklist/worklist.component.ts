import { Component, OnInit } from '@angular/core';
import { Process } from 'src/app/models/process.model';
import { WorklistService } from './worklist.service';
import { Task } from 'src/app/models/task.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'app-worklist',
    templateUrl: './worklist.component.html',
    styleUrls: ['./worklist.component.css']
})
export class WorklistComponent implements OnInit {

    constructor(private service: WorklistService,
        private route: ActivatedRoute,
        private router: Router) { }

    public processesList: Process[];

    ngOnInit() {
        this.loadProcesses();
    }

    async loadProcesses() {
        this.processesList = await this.service.getAll();
    }

    updateSelectedTask(task: Task, event: Event) {
        event.preventDefault();
        this.router.navigate(['task'])
        window.localStorage.setItem('task', JSON.stringify(task));
    }
}
