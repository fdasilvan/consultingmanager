import { Component, OnInit } from '@angular/core';
import { Task } from 'src/app/models/task.model';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { TaskService } from 'src/app/services/task/task.service';
import { Customer } from 'src/app/models/customer.model';

@Component({
    selector: 'app-worklist',
    templateUrl: './worklist.component.html',
    styleUrls: ['./worklist.component.css']
})
export class WorklistComponent implements OnInit {

    constructor(private service: TaskService,
        private route: ActivatedRoute,
        private router: Router) { }

    public tasksList: Task[];
    public loggedUser: User;
    
    ngOnInit() {

        this.loggedUser = <User>JSON.parse(sessionStorage.getItem('user'));

        if (!this.loggedUser) {
            this.router.navigate(['login']);
        }
        
        this.loadTasks();
    }

    async loadTasks() {
        debugger;
        this.tasksList = await this.service.getUserTasks(this.loggedUser.id);
    }

    updateSelectedTask(task: Task, event: Event) {
        event.preventDefault();
        this.router.navigate(['task'])
        window.localStorage.setItem('task', JSON.stringify(task));
    }

    updateSelectedCustomer(customer: Customer, event: Event) {
        debugger;
        event.preventDefault();
        window.localStorage.setItem("customer", JSON.stringify(customer));
        this.router.navigate(['timeline']);        
    }

    loadClassIndicator(task: Task) {
        let today: Date = new Date();
        today.setHours(0, 0, 0, 0);

        if (!task.endDate) {
            if (today > new Date(task.estimatedEndDate)) {
                return "indicator label-danger";
            } else if (today.getTime() >= new Date(task.startDate).getTime()) {
                return "indicator label-warning";
            } else {
                return "indicator label-default";
            }
        } else {
            return "indicator label-success";
        }
    }
}
