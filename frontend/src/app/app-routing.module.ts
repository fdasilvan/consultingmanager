import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WorklistComponent } from "./components/worklist/worklist.component"
import { CustomersListComponent } from './components/customers/customers-list/customers.component';
import { TimelineComponent } from './components/timeline/timeline.component';
import { TaskComponent } from './components/task/task.component';
import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';
import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { CustomerRegistrationComponent } from './components/customers/customer-registration/customer-registration.component';

const routes: Routes = [
  {
    path: '',
    component: AppComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'logout',
    component: LogoutComponent
  },
  {
    path: 'worklist',
    component: WorklistComponent
  },
  {
    path: 'timeline',
    component: TimelineComponent
  },
  {
    path: 'customers',
    component: CustomersListComponent
  },
  {
    path: 'customer-registration',
    component: CustomerRegistrationComponent
  },
  {
    path: 'dashboard',
    component: DashboardComponent
  },
  {
    path: 'task',
    component: TaskComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
