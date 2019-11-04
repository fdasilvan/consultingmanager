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
import { ProcessesListComponent } from './components/process/processes-list/processes-list.component';
import { ProcessRegistrationComponent } from './components/process/process-registration/process-registration.component';
import { CustomerMeetingsComponent } from './components/customers/customer-meetings/customer-meetings.component';
import { FlightplanComponent } from './components/flightplan/flightplan.component';
import { ConsultantRegistrationComponent } from './components/users/consultant-registration/consultant-registration.component';
import { ConsultantsListComponent } from './components/users/consultants-list/consultants-list.component';
import { CustomerContractsComponent } from './components/customers/customer-contracts/customer-contracts.component';
import { FinancialSummaryComponent } from './components/customers/financial-summary/financial-summary.component';

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
    path: 'processes',
    component: ProcessesListComponent
  },
  {
    path: 'process-registration',
    component: ProcessRegistrationComponent
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
    path: 'customer-meetings',
    component: CustomerMeetingsComponent
  },
  {
    path: 'customer-contracts',
    component: CustomerContractsComponent
  },
  {
    path: 'financial-summary',
    component: FinancialSummaryComponent
  },
  {
    path: 'flightplan',
    component: FlightplanComponent
  },
  {
    path: 'dashboard',
    component: DashboardComponent
  },
  {
    path: 'task',
    component: TaskComponent
  },
  {
    path: 'consultants-list',
    component: ConsultantsListComponent
  },
  {
    path: 'consultant-registration',
    component: ConsultantRegistrationComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
