import { Injectable, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from 'src/app/models/user.model';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class LoginService {

    constructor(private http: HttpClient) { }
    @Output() getLoggedInName: EventEmitter<any> = new EventEmitter();

    public async authenticate(user: User): Promise<User> {
        let response = await this.http.post<User>(`${environment.apiUrl}/authenticate`, user).toPromise();
        this.getLoggedInName.emit(response.name);
        return response;
    }
}
