import { Component, ElementRef, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { AuthService } from './services/auth/auth.service';
import { User } from './models/user.model';
import { Router } from '@angular/router';
import { UserService } from './services/user/user.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})


export class AppComponent implements OnInit {

    constructor(private router: Router,
        private authService: AuthService,
        private userService: UserService) {
        this.userService.userEvent.subscribe(response => {
            this.loggedUser = response;
        });
    }

    public loggedUser: User;

    ngOnInit() {
        this.loggedUser = this.userService.getUser();
        if (this.loggedUser) {
            this.router.navigate(['worklist']);
        } else {
            this.router.navigate(['login']);
        }
    }
}
