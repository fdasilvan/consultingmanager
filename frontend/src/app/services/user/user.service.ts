import { Injectable, EventEmitter } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  private loggedUser: User;
  public userEvent: EventEmitter<User> = new EventEmitter();

  getUser() {
    let user = <User>JSON.parse(localStorage.getItem('user'));

    if (user) {
      return user;
    } else {
      return this.loggedUser;
    }
  }

  setUser(user: User) {
    this.loggedUser = user;
    localStorage.setItem('user', JSON.stringify(user));
    this.userEvent.emit(user);
  }

  public async saveUser(userDto: User): Promise<User> {
    let response = this.http.post<User>(`${environment.apiUrl}/user`, userDto).toPromise();
    return response;
  }
}
