import { Injectable } from '@angular/core';
import { CustomerProcess } from 'src/app/models/customerprocess.model';
import { HttpClient } from '@angular/common/http';
import { Config } from 'src/config/config';
import { ModelProcess } from 'src/app/models/modelprocess.model';

@Injectable({
  providedIn: 'root'
})
export class ProcessService {

  constructor(private http: HttpClient) { }

  public async getModelProcesses(): Promise<ModelProcess[]> {
    var response = await this.http.get<ModelProcess[]>(`${Config.apiUrl}/process`);
    return response.toPromise();
  }

  public async startCustomerProcess(modelProcessId: string, modelProcessDescription: string, customerId: string,
    consultantId: string, customerUserId: string, startDate: Date): Promise<CustomerProcess> {

    let modelProcess: ModelProcess = new ModelProcess();
    modelProcess.id = modelProcessId;
    modelProcess.description = modelProcessDescription;

    let params = {
      modelProcessId: modelProcess.id,
      modelProcessDescription: modelProcess.description,
      customerId: customerId,
      consultantId: consultantId,
      customerUserId: customerUserId,
      startDate: startDate
    };

    let response = await this.http.post<CustomerProcess>(`${Config.apiUrl}/process`, params).toPromise();
    return response;
  }

  public async getCustomerProcesses(customerId: string): Promise<CustomerProcess[]> {
    var response = await this.http.get<CustomerProcess[]>(`${Config.apiUrl}/process/customer/${customerId}`);
    return response.toPromise();
  }
}
