import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Question } from '../models/question.model';

@Injectable()
export class QuestionsService {

  constructor(private http: HttpClient) { }

  get(): Observable<Question[]> {
    return this.http.get<Question[]>(environment.apiUrl + "questions", { withCredentials: true });
  }
  post(question: Question): Observable<Question>{ 
    return this.http.post<Question>(environment.apiUrl + "questions", question, {withCredentials: true});
  }

  delete(question: Question): Observable<void>{ 
    console.log(question);
    return this.http.delete<void>(environment.apiUrl + "questions/" + question.questionId, {withCredentials: true});
  }
}
