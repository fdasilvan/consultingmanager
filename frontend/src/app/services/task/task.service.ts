import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Config } from 'src/config/config';

@Injectable({
    providedIn: 'root'
})
export class TaskService {

    constructor(private http: HttpClient) { }

    public async finishTask(taskId: string) {
        let response = await this.http.post<any>(`${Config.apiUrl}/process/finish-task/${taskId}`, null).toPromise();
        return response;
    }
}
