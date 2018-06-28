import { Component, OnInit } from "@angular/core";
import { Question } from "../../models/question.model";
import { Answer } from "../../models/answer.model";
import { QuestionsService } from "../../services/questions.service";
import { AnswersService } from "../../services/answers.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"]
})
export class HomeComponent implements OnInit {
  selectedQuestion: Question;
  questions: Question[] = [{ questionId: 0, questionText: "How old is John" }];
  newQuestionText: string;
  selectedQuestionAnsweText: string;
  selectedIndexOfQuestion: number;
  constructor(
    private questionService: QuestionsService,
    private answerService: AnswersService
  ) {}

  ngOnInit() {
    this.questionService.get().subscribe(x => {
      console.log(x);
      this.questions = x;
    });
  }

  askQuestion(questionText: string) {
    const newQuestion: Question = { questionId: 0, questionText: questionText };
    this.questionService.post(newQuestion).subscribe((x: Question) => {
      this.questions = [...this.questions, x];
    });
    this.newQuestionText = "";
  }

  answerQuestion(question: Question, answerText: string) {
    const answer: Answer = {
      answerId: 0,
      answerText: answerText,
      questionId: question.questionId
    };
    this.answerService.answerQuestion(answer).subscribe(x => { 
      console.log(x);
    })
    if (question.answers) {
      question.answers = [...question.answers, answer];
    } else {
      question.answers = [answer];
    }
    this.selectedQuestionAnsweText = "";
  }
  selectQuestion(index: number) {
    if(this.selectedIndexOfQuestion === index) return;
    this.selectedIndexOfQuestion = index;
    const question = this.questions[index];
    this.answerService.get(question.questionId).subscribe(x => {
      console.log(x);
      question.answers = x;
    });
  }
}
