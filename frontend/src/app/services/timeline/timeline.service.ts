import { Injectable } from '@angular/core';
import { Process } from 'src/app/models/process.model';
import { Task } from 'src/app/models/task.model';
import { Step } from 'src/app/models/step.model';
import { HttpClient } from '@angular/common/http';
import { Config } from 'src/config/config';

@Injectable({
    providedIn: 'root'
})
export class TimelineService {

    constructor(private http: HttpClient) { }

    public async getProcesses(customerId: string): Promise<Process[]> {
        var response = await this.http.get<Process[]>(`${Config.apiUrl}/process?customerId=${customerId}`);
        return response.toPromise();
    }
}
