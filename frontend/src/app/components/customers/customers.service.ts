import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from 'src/app/models/customer.model';

@Injectable({
    providedIn: 'root'
})
export class CustomersService {

    constructor(private http: HttpClient) { }

    urlBase: string = 'http://localhost:3000';

    public async getAll(): Promise<Customer[]> {
        var response = await this.http.get<Customer[]>(`${this.urlBase}/customers`);
        return response.toPromise();
    }
}
