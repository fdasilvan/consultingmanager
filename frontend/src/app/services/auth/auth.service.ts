import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Config } from 'src/config/config';
import { User } from 'src/app/models/user.model';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    constructor(private _http: HttpClient) {
    }

    public async login(user: User) {
        let response = await this._http.post<User>(`${Config.apiUrl}/users/authenticate`, { email: user.email, password: user.password });
        return response.pipe(map(response => response));
    }
}