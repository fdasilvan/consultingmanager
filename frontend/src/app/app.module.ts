import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxMaskModule, IConfig } from 'ngx-mask';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomersListComponent } from './components/customers/customers-list/customers.component';
import { TimelineComponent } from './components/timeline/timeline.component';
import { HttpClientModule } from '@angular/common/http';
import { TaskComponent } from './components/task/task.component';
import { AuthService } from './services/auth/auth.service';
import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';
import { OrderByPipe } from './pipes/order-by.pipe';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ContentComponent } from './components/content/content.component';
import { CustomerRegistrationComponent } from './components/customers/customer-registration/customer-registration.component';
import { WorklistComponent } from './components/worklist/worklist.component';
import { ProcessesListComponent } from './components/process/processes-list/processes-list.component';
import { ProcessRegistrationComponent } from './components/process/process-registration/process-registration.component';
import { FormsModule } from '@angular/forms';
import { CustomerMeetingsComponent } from './components/customers/customer-meetings/customer-meetings.component';
import { FlightplanComponent } from './components/flightplan/flightplan.component';
import { CommentsComponent } from './components/comments/comments.component';
import { ProcessViewComponent } from './components/process/process-view/process-view.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomersListComponent,
    WorklistComponent,
    TimelineComponent,
    TaskComponent,
    LoginComponent,
    LogoutComponent,
    OrderByPipe,
    DashboardComponent,
    ContentComponent,
    CustomerRegistrationComponent,
    ProcessesListComponent,
    ProcessRegistrationComponent,
    CustomerMeetingsComponent,
    FlightplanComponent,
    CommentsComponent,
    ProcessViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    HttpClientModule,
    NgbModule,
    NgxChartsModule,
    BrowserAnimationsModule,
    FormsModule,
    NgxMaskModule.forRoot()
  ],
  providers: [AuthService],
  bootstrap: [AppComponent],
  entryComponents: [CustomerRegistrationComponent]
})
export class AppModule { }
