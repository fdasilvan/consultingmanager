import { Injectable, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from 'src/app/models/user.model';
import { Config } from 'src/config/config';

@Injectable({
    providedIn: 'root'
})
export class LoginService {

    constructor(private http: HttpClient) { }
    @Output() getLoggedInName: EventEmitter<any> = new EventEmitter();

    public async authenticate(user: User): Promise<User> {
        let response = await this.http.post<User>(`${Config.apiUrl}/authenticate`, user).toPromise();
        this.getLoggedInName.emit(response.name);
        return response;
    }
}
