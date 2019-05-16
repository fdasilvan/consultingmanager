import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from 'src/app/models/user.model';
import { Config } from 'src/config/config';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

    constructor(private http: HttpClient) { }

    public async authenticate(user: User): Promise<User> {
        return await this.http.post<User>(`${Config.apiUrl}/authenticate`, user).toPromise();
    }
}
