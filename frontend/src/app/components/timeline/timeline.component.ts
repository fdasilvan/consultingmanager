import { Component, OnInit } from '@angular/core';
import { TimelineService } from './timeline.service';
import { Process } from 'src/app/models/process.model';

@Component({
    selector: 'app-timeline',
    templateUrl: './timeline.component.html',
    styleUrls: ['./timeline.component.css']
})
export class TimelineComponent implements OnInit {

    constructor(private service: TimelineService) { }

    public processesList: Process[];
    ngOnInit() {
        this.loadProcesses();
    }

    async loadProcesses() {
        this.processesList = await this.service.getAll();
        debugger;
    }
}
