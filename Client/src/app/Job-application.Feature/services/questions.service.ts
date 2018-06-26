import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class QuestionsService {

  constructor(private http: HttpClient) { }

  getValues(): Observable<string[]> {
    return this.http.get<string[]>(environment.apiUrl + "values", { withCredentials: true });
  }
}
