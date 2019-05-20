import { Component, ElementRef, ViewChild, AfterViewInit, OnInit, Inject, PLATFORM_ID } from '@angular/core';
import { AuthService } from './services/auth/auth.service';
import { User } from './models/user.model';
import { Router } from '@angular/router';
import { environment } from '../environments/environment';
import { isPlatformBrowser, DOCUMENT } from '@angular/common';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})


export class AppComponent implements OnInit {

    constructor(@Inject(PLATFORM_ID) private platformId: any, @Inject(DOCUMENT) private document: any, private router: Router) { }

    public loggedUser: User;

    ngOnInit() {
        debugger;
        this.loggedUser = <User>JSON.parse(sessionStorage.getItem('user'));
        if (this.loggedUser) {
            this.router.navigate(['worklist']);
        } else {
            this.router.navigate(['login']);
        }

        if (!isPlatformBrowser(this.platformId)) {
            let bases = this.document.getElementsByTagName('base');

            if (bases.length > 0) {
                bases[0].setAttribute('href', environment.baseHref);
            }
        }
    }
}
