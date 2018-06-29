using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using Services.Interfaces;

namespace Services
{
  public class QuestionAnswerService : IQuestionAnswerService
  {
    public async Task<Question> DeleteQuestion(Question question)
    {
      foreach (var answer in question.Answers)
      {
        answer.Deleted = DateTime.Now;
      }
      question.Deleted = DateTime.Now;
      return question;
    }
  }
}
