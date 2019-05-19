import { Component, ElementRef, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { AuthService } from './services/auth/auth.service';
import { User } from './models/user.model';
import { Router } from '@angular/router';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})


export class AppComponent implements OnInit {

    constructor(private router: Router) { }

    public loggedUser: User;

    ngOnInit() {
        this.loggedUser = <User>JSON.parse(sessionStorage.getItem('user'));
        if (this.loggedUser) {
            this.router.navigate(['worklist']);
        } else {
            this.router.navigate(['login']);
        }
    }
}
