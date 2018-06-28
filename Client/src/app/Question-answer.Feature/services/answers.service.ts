import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Question } from '../models/question.model';
import { Answer } from '../models/answer.model';

@Injectable()
export class AnswersService {

  constructor(private http: HttpClient) { }

  get(questionId: number): Observable<Answer[]> {
    return this.http.get<Answer[]>(environment.apiUrl + "Answers/" + questionId, { withCredentials: true });
  }
  answerQuestion(question: Answer): Observable<Answer>{ 
    return this.http.post<Answer>(environment.apiUrl + "Answers", question, {withCredentials: true});
  }
}
