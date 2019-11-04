import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    title = 'ConsultingManager';

    public user: User;

    @ViewChild('email') email;
    @ViewChild('password') password;

    constructor(private service: AuthService,
        private router: Router) { }

    ngOnInit() {
    }

    @Output() updateUser: EventEmitter<any> = new EventEmitter();
    async login() {
        let user: User = new User();

        user.email = this.email.nativeElement.value;
        user.password = this.password.nativeElement.value;

        try {
            let response = await this.service.login(user);
            sessionStorage.setItem('user', JSON.stringify(response));
            this.router.navigate(['worklist']);
        } catch (error) {
            if (error.status == 400) {
                alert('Usuário/senha inválidos!');
            } else {
                alert('Erro!');
            }
        }
    }
}
