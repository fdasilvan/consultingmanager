import { BrowserModule, BrowserTransferStateModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule, RoutingComponents } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomersComponent } from './components/customers/customers.component';
import { TimelineComponent } from './components/timeline/timeline.component';
import { HttpClientModule } from '@angular/common/http';
import { TaskComponent } from './components/task/task.component';
import { AuthService } from './services/auth/auth.service';
import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';
import { OrderByPipe } from './pipes/order-by.pipe';
import { AppModule } from './app.module';

@NgModule({
    imports: [
        
        AppRoutingModule,
        RouterModule,
        HttpClientModule,
        NgbModule,
        AppModule,
        BrowserTransferStateModule
    ],
    providers: [AuthService],
    bootstrap: [AppComponent]
})
export class AppBrowserModule { }
