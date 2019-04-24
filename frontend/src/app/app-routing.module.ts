import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WorklistComponent } from "./components/worklist/worklist.component"
import { CustomersComponent } from './components/customers/customers.component';
import { TimelineComponent } from './components/timeline/timeline.component';

const routes: Routes = [
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
    component: CustomersComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
export const RoutingComponents = [ WorklistComponent, CustomersComponent, TimelineComponent ];
