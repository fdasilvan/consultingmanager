import { Injectable, EventEmitter } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { CustomerMeeting } from 'src/app/models/customermeeting.model';
import { UserType } from 'src/app/models/usertype.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  private loggedUser: User;
  public userEvent: EventEmitter<User> = new EventEmitter();

  getLoggedUser() {
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

  public async getUserMeetings(userId: string): Promise<CustomerMeeting[]> {
    var response = await this.http.get<CustomerMeeting[]>(`${environment.apiUrl}/user/${userId}/meetings`);
    return response.toPromise();
  }

  public async getUser(userId: string): Promise<User> {
    var response = await this.http.get<User>(`${environment.apiUrl}/user/${userId}`);
    return response.toPromise();
  }

  public async getUserTypes(): Promise<UserType[]> {
    var response = await this.http.get<UserType[]>(`${environment.apiUrl}/user/user-types`);
    return response.toPromise();
  }

  public async saveConsultant(userDto: User): Promise<User> {
    let response = this.http.post<User>(`${environment.apiUrl}/user/consultant`, userDto).toPromise();
    return response;
  }
}
