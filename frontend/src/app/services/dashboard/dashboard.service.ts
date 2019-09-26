import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { CustomerTask } from 'src/app/models/customertask.model';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  constructor(private http: HttpClient) { }

  public async getConsultantsTasks(): Promise<CustomerTask[]> {
    var response = await this.http.get<CustomerTask[]>(`${environment.apiUrl}/dashboard/consultants/tasks`);
    return response.toPromise();
  }
}
