import { Injectable } from '@angular/core';
import { CustomerTask } from 'src/app/models/customertask.model';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private http: HttpClient) { }

  public async getTask(taskId: string): Promise<CustomerTask> {
    var response = await this.http.get<CustomerTask>(`${environment.apiUrl}/task/${taskId}`);
    return response.toPromise();
  }

  public async finishTask(taskId: string) {
    let response = await this.http.post<any>(`${environment.apiUrl}/task/${taskId}/finish`, null).toPromise();
    return response;
  }

  public async reopenTask(taskId: string) {
    let response = await this.http.post<any>(`${environment.apiUrl}/task/${taskId}/reopen`, null).toPromise();
    return response;
  }

  public async rescheduleTask(taskId: string, newDate: Date) {
    let response = await this.http.post<any>(`${environment.apiUrl}/task/${taskId}/reschedule/${newDate}`, null).toPromise();
    return response;
  }

  public async transferTask(taskId: string, consultantId: string) {
    let response = await this.http.put<any>(`${environment.apiUrl}/task/${taskId}/transfer/${consultantId}`, null).toPromise();
    return response;
  }

  public async getUserTasks(userId: string): Promise<CustomerTask[]> {
    var response = await this.http.get<CustomerTask[]>(`${environment.apiUrl}/task/user/${userId}`);
    return response.toPromise();
  }
}
