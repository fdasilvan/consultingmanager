import { Injectable, EventEmitter } from '@angular/core';
import { User } from 'src/app/models/user.model';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    constructor() { }

    private loggedUser: User;
    public userEvent: EventEmitter<User> = new EventEmitter();

    getUser() {
        return this.loggedUser;
    }

    setUser(user: User) {
        this.loggedUser = user;
        this.userEvent.emit(user);
    }

    login() {

    }

    logout() {

    }
}
