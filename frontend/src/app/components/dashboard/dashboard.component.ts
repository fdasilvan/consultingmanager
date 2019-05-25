import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';
import { CustomersService } from 'src/app/services/customers/customers.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private userService: UserService,
    private customerService: CustomersService,
    private route: ActivatedRoute,
    private router: Router) {
    this.loggedUser = this.userService.getUser();

    if (!this.loggedUser) {
      this.router.navigate(['login']);
    }
  }

  public loggedUser: User;

  public single: any[];
  multi: any[];

  view: any[] = [800, 400];

  // options
  showXAxis = true;
  showYAxis = true;
  gradient = false;
  showLegend = true;
  showXAxisLabel = true;
  xAxisLabel = 'Cliente';
  showYAxisLabel = true;
  yAxisLabel = 'Ativ. Atrasadas';
  showDataLabel = true;

  colorScheme = {
    domain: ['#5AA454', '#A10A28', '#C7B42C', '#AAAAAA']
  };

  ngOnInit() {
    this.loadConsultantChart();
  }

  async loadConsultantChart() {
    this.single = await this.customerService.getChartResult();
    this.single = this.single.map(x => ({ name: x.description, value: x.value }))
    // this.single = [
    //   {
    //     "name": "Germany",
    //     "value": 8940000
    //   },
    //   {
    //     "name": "USA",
    //     "value": 5000000
    //   },
    //   {
    //     "name": "France",
    //     "value": 7200000
    //   }
    // ];
  }
}
