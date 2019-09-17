import { Component, OnInit } from '@angular/core';
import { CustomerTask } from 'src/app/models/customertask.model';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { TaskService } from 'src/app/services/task/task.service';
import { Customer } from 'src/app/models/customer.model';
import { UserService } from 'src/app/services/user/user.service';
import { CustomerMeeting } from 'src/app/models/customermeeting.model';

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

  public tasksList: CustomerTask[];
  public filteredTasksList: CustomerTask[] = [];
  public loggedUser: User;
  public customersList: string[] = [];
  public selectedCustomerFilter: string;
  public isCustomer: boolean;
  public userMeetings: CustomerMeeting[] = [];
  public filteredUserMeetings: CustomerMeeting[] = []
  public today: Date = new Date();

  ngOnInit() {
    this.loggedUser = this.userService.getUser();
    this.isCustomer = this.loggedUser.userType.description == 'Cliente';

    if (!this.loggedUser) {
      this.router.navigate(['login']);
    }

    this.today.setHours(0, 0, 0, 0);

    this.selectedCustomerFilter = '';
    this.loadTasks();
    this.loadUserMeetings();
  }

  async loadTasks() {
    this.tasksList = await this.taskService.getUserTasks(this.loggedUser.id);
    this.filteredTasksList = this.tasksList;

    if (!this.isCustomer) {
      this.loadCustomersList();
      this.selectedCustomerFilter = window.sessionStorage.getItem('selectedCustomerFilter');
      if (this.selectedCustomerFilter && this.selectedCustomerFilter != 'null') {
        this.onCustomerChange(this.selectedCustomerFilter);
      }
    }
  }

  async loadUserMeetings() {
    this.userMeetings = await this.userService.getUserMeetings(this.loggedUser.id);
    this.filteredUserMeetings = this.userMeetings.filter(o => {
      let meetingDate = new Date(o.date);
      meetingDate.setHours(0, 0, 0, 0);
      return (meetingDate.getTime() == this.today.getTime());
    });
  }

  onMeetingDateChanged(date: Date) {
    if (date) {
      let selectedDay = new Date(date + "T00:00");
      this.filteredUserMeetings = this.userMeetings.filter(o => {
        let meetingDate = new Date(o.date);
        let datesMatch = (meetingDate.getTime() == selectedDay.getTime());
        return datesMatch;
      });
    }
  }

  openCustomerTimeline(customer: Customer) {
    window.sessionStorage.setItem('customer', JSON.stringify(customer));
    this.router.navigate(['timeline']);
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

  updateSelectedTask(task: CustomerTask, event: Event) {
    event.preventDefault();
    this.router.navigate(['task'])
    window.localStorage.setItem('taskId', task.id);
  }

  updateSelectedCustomer(customer: Customer, event: Event) {
    event.preventDefault();
    window.sessionStorage.setItem('customer', JSON.stringify(customer));
    this.router.navigate(['timeline']);
  }

  loadClassIndicator(task: CustomerTask) {
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
