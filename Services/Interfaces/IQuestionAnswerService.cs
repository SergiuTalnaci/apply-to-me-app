using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
  public interface IQuestionAnswerService
    {
    Task<Question> DeleteQuestion(Question question);
    }
}
