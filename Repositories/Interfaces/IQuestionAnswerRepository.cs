using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
  public interface IQuestionAnswerRepository
  {
    /// <summary>
    /// Save a question and return true if succes or false if fail.
    /// </summary>
    /// <param name="answer"></param>
    /// <returns></returns>
    Task<bool> AskQuestion(Question question);
    /// <summary>
    /// Save a answer for a question and return true if succes or false if fail.
    /// </summary>
    /// <param name="answer"></param>
    /// <returns></returns>
    Task<bool> AnswerQuestion(Answer answer);
    Task<bool> DeleteQuestion(int questionId);
    Task<bool> DeleteAnswer(int answerId);
    Task<ICollection<Question>> GetQuestions();
    Task<ICollection<Answer>> GetAnswers(int questionId);
  }
}
