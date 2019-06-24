import { Component, OnInit } from '@angular/core';
import { Task } from 'src/app/models/task.model';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { TaskService } from 'src/app/services/task/task.service';
import { Customer } from 'src/app/models/customer.model';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-worklist',
  templateUrl: './worklist.component.html',
  styleUrls: ['./worklist.component.css']
})
export class WorklistComponent implements OnInit {

  constructor(private taskService: TaskService,
    private userService: UserService,
    private route: ActivatedRoute,
    private router: Router) { }

  public tasksList: Task[];
  public filteredTasksList: Task[] = [];
  public loggedUser: User;
  public customersList: string[] = [];
  public selectedCustomerFilter: string;

  ngOnInit() {
    this.loggedUser = this.userService.getUser();

    if (!this.loggedUser) {
      this.router.navigate(['login']);
    }

    this.selectedCustomerFilter = '';
    this.loadTasks();
  }

  async loadTasks() {
    this.tasksList = await this.taskService.getUserTasks(this.loggedUser.id);
    this.filteredTasksList = this.tasksList;
    this.loadCustomersList();
    this.selectedCustomerFilter = window.sessionStorage.getItem('selectedCustomerFilter');
    if (this.selectedCustomerFilter && this.selectedCustomerFilter != 'null') {
      this.onCustomerChange(this.selectedCustomerFilter);
    }
  }

  async loadCustomersList() {
    if (this.tasksList && this.tasksList.length > 0) {
      for (let i = 0; i < this.tasksList.length; i++) {
        let task = this.tasksList[i];
        if (this.customersList.indexOf(task.customer.name) < 0) {
          this.customersList.push(task.customer.name);
          this.customersList.sort((a, b) => a.localeCompare(b));
        }
      }
    }
  }

  updateSelectedTask(task: Task, event: Event) {
    event.preventDefault();
    this.router.navigate(['task'])
    window.localStorage.setItem('task', JSON.stringify(task));
  }

  updateSelectedCustomer(customer: Customer, event: Event) {
    event.preventDefault();
    window.localStorage.setItem('customer', JSON.stringify(customer));
    this.router.navigate(['timeline']);
  }

  loadClassIndicator(task: Task) {
    let today: Date = new Date();
    today.setHours(0, 0, 0, 0);

    if (!task.endDate) {
      if (today > new Date(task.estimatedEndDate)) {
        return 'indicator label-danger';
      } else if (today.getTime() >= new Date(task.startDate).getTime()) {
        return 'indicator label-warning';
      } else {
        return 'indicator label-default';
      }
    } else {
      return 'indicator label-success';
    }
  }

  async onCustomerChange(customerName: string) {
    window.sessionStorage.setItem('selectedCustomerFilter', customerName);
    if (customerName == '') {
      this.filteredTasksList = this.tasksList;
    } else {
      this.filteredTasksList = this.tasksList.filter(task => task.customer.name == customerName);
    }
  }
}
