import { Answer } from "./answer.model";

export class Question { 
    questionId: number;
    questionText: string;
    deleted?: Date;
    answers?: Answer[];
}