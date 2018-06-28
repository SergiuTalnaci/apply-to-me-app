"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var HomeComponent = /** @class */ (function () {
    function HomeComponent() {
        this.questions = [{ questionId: 0, questionText: "How old is John" }];
    }
    HomeComponent.prototype.ngOnInit = function () { };
    HomeComponent.prototype.askQuestion = function (questionText) {
        var newQuestion = { questionId: 0, questionText: questionText };
        this.questions = this.questions.concat([newQuestion]);
        console.log(this.questions);
        this.newQuestionText = "";
    };
    HomeComponent.prototype.answerQuestion = function (question, answerText) {
        console.log(answerText);
        var answer = { answerId: 0, answerText: answerText, questionId: question.questionId };
        if (question.answers)
            question.answers = question.answers.concat([answer]);
        else {
            question.answers = [answer];
        }
        this.selectedQuestionAnsweText = "";
    };
    HomeComponent.prototype.selectQuestion = function (index) {
        this.selectedIndexOfQuestion = index;
    };
    HomeComponent = __decorate([
        core_1.Component({
            selector: "app-home",
            templateUrl: "./home.component.html",
            styleUrls: ["./home.component.css"]
        }),
        __metadata("design:paramtypes", [])
    ], HomeComponent);
    return HomeComponent;
}());
exports.HomeComponent = HomeComponent;
//# sourceMappingURL=home.component.js.map