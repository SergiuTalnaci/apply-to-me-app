using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
  interface IQuestionAnswerRepository
    {
    Task AskQuestion(Question question);
    Task AnswerQuestion(Answer answer);
    Task DeleteQuestion(int questionId);
    Task DeleteAnswer(int answerId);
    Task<ICollection<Question>> GetQuestions();
    Task<ICollection<Answer>> GetAnswers(int questionId);
    }
}
