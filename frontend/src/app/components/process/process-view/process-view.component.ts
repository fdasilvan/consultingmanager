import { Component, OnInit, Input } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';
import { Router } from '@angular/router';
import { ModelProcess } from 'src/app/models/modelprocess.model';
import { ProcessService } from 'src/app/services/process/process.service';

@Component({
  selector: 'app-process-view',
  templateUrl: './process-view.component.html',
  styleUrls: ['./process-view.component.css']
})
export class ProcessViewComponent implements OnInit {

  constructor(private userService: UserService,
    private processService: ProcessService,
    private router: Router) { }

  public loggedUser: User;
  public modelProcess: ModelProcess;
  public showContent: boolean;
  @Input() modelProcessId: string;

  async ngOnInit() {
    this.validateUser();
    await this.loadModelProcess();
    this.showContent = (this.modelProcess && this.modelProcess.modelSteps && this.modelProcess.modelSteps.length > 0);
  }

  validateUser() {
    this.loggedUser = this.userService.getUser();

    if (!this.loggedUser) {
      this.router.navigate(['login']);
    }
  }

  async loadModelProcess() {
    if (this.modelProcessId && this.modelProcessId != '') {
      this.modelProcess = await this.processService.getModelProcess(this.modelProcessId);
    }
  }
}
