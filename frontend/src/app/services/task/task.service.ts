import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Config } from 'src/config/config';
import { Task } from 'src/app/models/task.model';

@Injectable({
    providedIn: 'root'
})
export class TaskService {

    constructor(private http: HttpClient) { }

    public async finishTask(taskId: string) {
        let response = await this.http.post<any>(`${Config.apiUrl}/process/finish-task/${taskId}`, null).toPromise();
        return response;
    }

    public async getUserTasks(userId: string): Promise<Task[]> {
        var response = await this.http.get<Task[]>(`${Config.apiUrl}/process/user-tasks/${userId}`);
        return response.toPromise();
    }
}
