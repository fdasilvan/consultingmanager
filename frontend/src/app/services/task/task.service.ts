import { Injectable } from '@angular/core';
import { Task } from 'src/app/models/task.model';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private http: HttpClient) { }

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

  public async getUserTasks(userId: string): Promise<Task[]> {
    var response = await this.http.get<Task[]>(`${environment.apiUrl}/task/user/${userId}`);
    return response.toPromise();
  }
}
