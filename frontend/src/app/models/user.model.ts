import { UserType } from './usertype.model';

export class User {
    id: string;
    name: string;
    email: string;
    password: string;
    userTypeId: string;
    userType: UserType;

    constructor() {
    }
}
