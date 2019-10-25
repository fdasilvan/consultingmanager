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
import { CustomerMeeting } from 'src/app/models/customermeeting.model';
import { CustomerLevel } from 'src/app/models/customerlevel.model';
import { Team } from 'src/app/models/team.model';
import { CancellationReason } from 'src/app/models/cancellationreason.model';
import { CustomerCancellation } from 'src/app/models/customercancellation.model';
import { CustomerContact } from 'src/app/models/customercontact.model';

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

  public async transferCustomer(customerId: string, consultantId: string) {
    let response = await this.http.put<Customer>(`${environment.apiUrl}/customer/transfer`, {}, { params: { customerId: customerId, consultantId: consultantId } }).toPromise();
    return response;
  }

  public async saveMeetings(customerId: string, customerMeetings: CustomerMeeting[]): Promise<boolean> {
    let response = await this.http.post<boolean>(`${environment.apiUrl}/customer/${customerId}/meetings`, customerMeetings).toPromise();
    return response;
  }

  public async getMeetings(customerId: string): Promise<CustomerMeeting[]> {
    var response = await this.http.get<CustomerMeeting[]>(`${environment.apiUrl}/customer/${customerId}/meetings`);
    return response.toPromise();
  }

  public async saveContacts(customerId: string, customerContacts: CustomerContact[]): Promise<boolean> {
    let response = await this.http.post<boolean>(`${environment.apiUrl}/customer/${customerId}/contacts`, customerContacts).toPromise();
    return response;
  }

  public async getContacts(customerId: string): Promise<CustomerContact[]> {
    var response = await this.http.get<CustomerContact[]>(`${environment.apiUrl}/customer/${customerId}/contacts`);
    return response.toPromise();
  }

  public async getAll(): Promise<Customer[]> {
    var response = await this.http.get<Customer[]>(`${environment.apiUrl}/customer`);
    return response.toPromise();
  }

  public async getCustomer(customerId: string): Promise<Customer> {
    var response = await this.http.get<Customer>(`${environment.apiUrl}/customer/${customerId}`);
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

  public async getCustomerCategories(): Promise<CustomerCategory[]> {
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

  public async getCustomerLevels(): Promise<CustomerLevel[]> {
    var response = await this.http.get<CustomerLevel[]>(`${environment.apiUrl}/customer/levels`);
    return response.toPromise();
  }

  public async getConsultants(): Promise<User[]> {
    var response = await this.http.get<User[]>(`${environment.apiUrl}/customer/consultants`);
    return response.toPromise();
  }

  public async getTeams(): Promise<Team[]> {
    var response = await this.http.get<Team[]>(`${environment.apiUrl}/customer/teams`);
    return response.toPromise();
  }

  public async getCancellationReasons(): Promise<CancellationReason[]> {
    var response = await this.http.get<CancellationReason[]>(`${environment.apiUrl}/customer/cancellation-reasons`);
    return response.toPromise();
  }

  public async addCustomerCancellation(customerCancellationDto: CustomerCancellation): Promise<CustomerCancellation> {
    let response = await this.http.post<CustomerCancellation>(`${environment.apiUrl}/customer/cancellation`, customerCancellationDto).toPromise();
    return response;
  }

  public async addPlatform(platformDto: Platform): Promise<Platform> {
    let response = await this.http.post<Platform>(`${environment.apiUrl}/customer/platform`, platformDto).toPromise();
    return response;
  }
}
