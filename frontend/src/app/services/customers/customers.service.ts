import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from 'src/app/models/customer.model';
import { Config } from 'src/config/config';
import { ChartResult } from 'src/app/models/chartresult.model';

@Injectable({
    providedIn: 'root'
})
export class CustomersService {

    constructor(private http: HttpClient) { }

    public async getAll(): Promise<Customer[]> {
        var response = await this.http.get<Customer[]>(`${Config.apiUrl}/customer`);
        return response.toPromise();
    }

    public async getChartResult(): Promise<ChartResult[]> {
      var response = await this.http.get<ChartResult[]>(`${Config.apiUrl}/customer/chart`);
      return response.toPromise();
  }
}
