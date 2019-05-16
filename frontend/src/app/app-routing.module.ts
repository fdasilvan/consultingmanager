import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WorklistComponent } from "./components/worklist/worklist.component"
import { CustomersComponent } from './components/customers/customers.component';
import { TimelineComponent } from './components/timeline/timeline.component';
import { TaskComponent } from './components/task/task.component';
import { AuthGuardService } from './services/auth/auth-guard.service';
import { AuthCallbackComponent } from './components/auth-callback/auth-callback.component';

const routes: Routes = [
    {
        path: 'worklist',
        component: WorklistComponent,
        canActivate: [AuthGuardService]
    },
    {
        path: 'timeline',
        component: TimelineComponent,
        canActivate: [AuthGuardService]
    },
    {
        path: 'customers',
        component: CustomersComponent,
        canActivate: [AuthGuardService]
    },
    {
        path: 'task',
        component: TaskComponent,
        canActivate: [AuthGuardService]
    },
    {
        path: 'auth-callback',
        component: AuthCallbackComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
export const RoutingComponents = [WorklistComponent, CustomersComponent, TimelineComponent];
