import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from 'src/app/models/customer.model';
import { Config } from 'src/config/config';
import { ChartResult } from 'src/app/models/chartresult.model';
import { environment } from 'src/environments/environment';
import { City } from 'src/app/models/city.model';
import { Platform } from 'src/app/models/platform.model';
import { CustomerCategory } from 'src/app/models/customercategory.model';
import { Plan } from 'src/app/models/plan.model';
import { CustomerSituation } from 'src/app/models/customersituation.model';
import { User } from 'src/app/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  constructor(private http: HttpClient) { }

  public async saveCustomer(customerDto: Customer): Promise<Customer> {
    if (customerDto.id) {
      let response = await this.http.put<Customer>(`${environment.apiUrl}/customer`, customerDto).toPromise();
      return response;
    } else {
      let response = await this.http.post<Customer>(`${environment.apiUrl}/customer`, customerDto).toPromise();
      return response;
    }
  }

  public async getAll(): Promise<Customer[]> {
    var response = await this.http.get<Customer[]>(`${environment.apiUrl}/customer`);
    return response.toPromise();
  }

  public async getChartResult(): Promise<ChartResult[]> {
    var response = await this.http.get<ChartResult[]>(`${environment.apiUrl}/customer/chart`);
    return response.toPromise();
  }

  public async getCities(): Promise<City[]> {
    var response = await this.http.get<City[]>(`${environment.apiUrl}/customer/cities`);
    return response.toPromise();
  }

  public async getPlatforms(): Promise<Platform[]> {
    var response = await this.http.get<Platform[]>(`${environment.apiUrl}/customer/platforms`);
    return response.toPromise();
  }

  public async getCategories(): Promise<CustomerCategory[]> {
    var response = await this.http.get<CustomerCategory[]>(`${environment.apiUrl}/customer/categories`);
    return response.toPromise();
  }

  public async getPlans(): Promise<Plan[]> {
    var response = await this.http.get<Plan[]>(`${environment.apiUrl}/customer/plans`);
    return response.toPromise();
  }

  public async getSituations(): Promise<CustomerSituation[]> {
    var response = await this.http.get<CustomerSituation[]>(`${environment.apiUrl}/customer/situations`);
    return response.toPromise();
  }

  public async getConsultants(): Promise<User[]> {
    var response = await this.http.get<User[]>(`${environment.apiUrl}/customer/consultants`);
    return response.toPromise();
  }
}
