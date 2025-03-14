import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user/user.service';

@Component({
    selector: 'app-logout',
    templateUrl: './logout.component.html',
    styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

    constructor(private router: Router,
        private userService: UserService) { }

    ngOnInit() {
        this.userService.setUser(null);
        this.router.navigate(['']);
    }
}
