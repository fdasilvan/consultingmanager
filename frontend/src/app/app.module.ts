import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule, RoutingComponents } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomersComponent } from './components/customers/customers.component';
import { TimelineComponent } from './components/timeline/timeline.component';
import { HttpClientModule } from '@angular/common/http';
import { TaskComponent } from './components/task/task.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { AuthGuardService } from './services/auth/auth-guard.service';
import { AuthService } from './services/auth/auth.service';
import { AuthCallbackComponent } from './components/auth-callback/auth-callback.component';

@NgModule({
    declarations: [
        AppComponent,
        RoutingComponents,
        CustomersComponent,
        TimelineComponent,
        TaskComponent,
        LoginComponent,
        HomeComponent,
        AuthCallbackComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        RouterModule,
        HttpClientModule,
        NgbModule
    ],
    providers: [AuthGuardService, AuthService],
    bootstrap: [AppComponent]
})
export class AppModule { }
