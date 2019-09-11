import { Injectable } from '@angular/core';
import { CustomerProcess } from 'src/app/models/customerprocess.model';
import { HttpClient } from '@angular/common/http';
import { Config } from 'src/config/config';
import { ModelProcess } from 'src/app/models/modelprocess.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProcessService {

  constructor(private http: HttpClient) { }

  public async getModelProcesses(): Promise<ModelProcess[]> {
    var response = await this.http.get<ModelProcess[]>(`${environment.apiUrl}/process`);
    return response.toPromise();
  }

  public async getModelProcess(modelProcessId): Promise<ModelProcess> {
    var response = await this.http.get<ModelProcess>(`${environment.apiUrl}/process/model/${modelProcessId}`);
    return response.toPromise();
  }

  public async startCustomerProcess(modelProcessId: string, modelProcessDescription: string, detail: string, customerId: string,
    consultantId: string, customerUserId: string, startDate: Date, customerMeetingId: string): Promise<CustomerProcess> {

    let modelProcess: ModelProcess = new ModelProcess();
    modelProcess.id = modelProcessId;
    modelProcess.description = modelProcessDescription;

    let params = {
      modelProcessId: modelProcess.id,
      modelProcessDescription: modelProcess.description,
      detail: detail,
      customerId: customerId,
      consultantId: consultantId,
      customerUserId: customerUserId,
      startDate: startDate,
      customerMeetingId: customerMeetingId
    };

    let response = await this.http.post<CustomerProcess>(`${environment.apiUrl}/process/start`, params).toPromise();
    return response;
  }

  public async saveProcess(modelProcess: ModelProcess): Promise<boolean> {
    let response = await this.http.post<boolean>(`${environment.apiUrl}/process`, modelProcess).toPromise();
    return response;
  }

  public async delete(customerProcessId: string): Promise<boolean> {
    let response = await this.http.delete<boolean>(`${environment.apiUrl}/process`, { params: { customerProcessId: customerProcessId } }).toPromise();
    return response;
  }

  public async getCustomerProcesses(customerId: string): Promise<CustomerProcess[]> {
    var response = await this.http.get<CustomerProcess[]>(`${environment.apiUrl}/process/customer/${customerId}`);
    return response.toPromise();
  }
}
