import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';

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

    async login() {
        let user: User = new User();

        user.email = this.email.nativeElement.value;
        user.password = this.password.nativeElement.value;

        let response = await this.service.login(user);

        response.subscribe(resp => {
            sessionStorage.setItem("user", JSON.stringify(user));
            this.router.navigate(['worklist']);
        }, error => {
            if (error.status == 400) {
                alert('Usuário/senha inválidos!');
            } else {
                alert('Erro!');
            }
        });
    }
}
