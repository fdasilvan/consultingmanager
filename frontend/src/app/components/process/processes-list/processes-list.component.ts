import { Component, OnInit } from '@angular/core';
import { ModelProcess } from 'src/app/models/modelprocess.model';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';
import { Router } from '@angular/router';
import { ProcessService } from 'src/app/services/process/process.service';

@Component({
  selector: 'app-processes-list',
  templateUrl: './processes-list.component.html',
  styleUrls: ['./processes-list.component.css']
})
export class ProcessesListComponent implements OnInit {

  constructor(private userService: UserService,
    private processService: ProcessService,
    private router: Router) { }

  public processes: ModelProcess[] = [];
  public loggedUser: User;

  ngOnInit() {
    this.loggedUser = this.userService.getUser();
    if (!this.loggedUser) {
      this.router.navigate(['login']);
    }

    this.loadProcesses();
  }

  async loadProcesses() {
    this.processes = await this.processService.getModelProcesses();
  }

  selectProcess(process) {
    window.sessionStorage.setItem('modelProcess', JSON.stringify(process));
    this.router.navigate(['process-registration']);
  }
}
