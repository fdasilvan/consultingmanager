import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Comment } from 'src/app/models/comment.model';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private http: HttpClient) { }

  public async add(comment: Comment) {
    let response = await this.http.post<any>(`${environment.apiUrl}/comment`, comment).toPromise();
    return response;
  }

  public async getMeetingComments(customerMeetingId: string) {
    var response = await this.http.get<Comment[]>(`${environment.apiUrl}/comment/meeting/${customerMeetingId}`);
    return response.toPromise();
  }

  public async getCustomerComments(customerId: string) {
    var response = await this.http.get<Comment[]>(`${environment.apiUrl}/comment/customer/${customerId}`);
    return response.toPromise();
  }
}
