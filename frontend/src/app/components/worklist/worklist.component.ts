import { Component, OnInit } from '@angular/core';
import { Process } from 'src/app/models/process.model';
import { WorklistService } from '../../services/worklist/worklist.service';
import { Task } from 'src/app/models/task.model';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user.model';

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
    public loggedUser: User;
    
    ngOnInit() {

        this.loggedUser = <User>JSON.parse(sessionStorage.getItem('user'));

        if (!this.loggedUser) {
            this.router.navigate(['login']);
        }
        
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

    loadClassIndicator(task: Task) {
        let today: Date = new Date();
        today.setHours(0, 0, 0, 0);

        if (!task.estimatedEndDate) {
            if (today > task.endDate) {
                return "indicator label-danger";
            } else if (today.getTime() >= task.startDate.getTime()) {
                return "indicator label-warning";
            } else {
                return "indicator label-default";
            }
        } else {
            return "indicator label-success";
        }
    }
}
