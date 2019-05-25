import { Injectable, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Config } from 'src/config/config';
import { User } from 'src/app/models/user.model';
import { UserService } from '../user/user.service';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    constructor(private http: HttpClient,
        private userService: UserService) {
    }

    updateUser: EventEmitter<any> = new EventEmitter();
    public async login(user: User): Promise<User> {
        let response = await this.http.post<User>(`${environment.apiUrl}/users/authenticate`, { email: user.email, password: user.password }).toPromise();
        this.userService.setUser(response);
        return response;
    }
}