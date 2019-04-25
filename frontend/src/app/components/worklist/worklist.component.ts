import { Component, OnInit } from '@angular/core';
import { Process } from 'src/app/models/process.model';
import { WorklistService } from './worklist.service';

@Component({
    selector: 'app-worklist',
    templateUrl: './worklist.component.html',
    styleUrls: ['./worklist.component.css']
})
export class WorklistComponent implements OnInit {

    constructor(private service: WorklistService) { }

    public processesList: Process[];

    ngOnInit() {
        this.loadProcesses();
    }

    async loadProcesses() {
        this.processesList = await this.service.getAll();
        debugger;
    }
}
