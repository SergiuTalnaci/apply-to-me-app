using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Interfaces;

namespace Repositories
{
  public class QuestionAnswerRepository : IQuestionAnswerRepository
  {
    private readonly AppDb _context;
    private readonly ILogger<QuestionAnswerRepository> _logger;
    public QuestionAnswerRepository(AppDb context, ILogger<QuestionAnswerRepository> logger)
    {
      _context = context;
      _logger = logger;
    }
    public async Task<bool> AnswerQuestion(Answer answer)
    {
      try
      {
        _context.Answers.Add(answer);
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Saved new answer for question:{answer?.QuestionId}");
        return true;
      }
      catch (Exception e)
      {
        _logger.LogError($"Fail saving new answer for question:{answer?.QuestionId}, {e.StackTrace}");
        return false;
      }
    }

    public async Task<bool> AskQuestion(Question question)
    {
      try
      {
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Saved new question:{question?.QuestionId}");
        return true;
      }
      catch (Exception e)
      {
        _logger.LogError($"Fail saving new question:{question?.QuestionId}, {e.StackTrace}");
        return false;
      }
    }

    public async Task<bool> DeleteAnswer(int answerId)
    {
      try
      {
        var answer = await _context.Answers.FirstOrDefaultAsync(x => x.AnswerId == answerId);
        if (answer == null) return false;
        answer.Deleted = DateTime.Now;
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Deleted answer: {answerId}");
        return true;
      }
      catch (Exception e)
      {
        _logger.LogError($"Fail deleting answer:{answerId}, {e.StackTrace}");
        return false;
      }

    }

    public async Task<bool> DeleteQuestion(int questionId)
    {
      try
      {
        var question = await _context.Questions.FirstOrDefaultAsync(x => x.QuestionId == questionId);
        if (question == null) return false;
        var answers = await _context.Answers.Where(x => x.QuestionId == questionId).ToListAsync();
        answers.ForEach(x => x.Deleted = DateTime.Now);
        question.Deleted = DateTime.Now;
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Deleted question: {questionId} and all the answers");
        return true;
      }
      catch (Exception e)
      {
        _logger.LogError($"Fail deleting question:{questionId}, {e.StackTrace}");
        return false;
      }

    }

    public async Task<ICollection<Answer>> GetAnswers(int questionId)
    {
      try
      {
        var answers = await _context.Answers
       .Where(x => x.QuestionId == questionId)
       .Where(x => x.Deleted == null)
       .ToListAsync();
        return answers;
      }
      catch (Exception e)
      {
        _logger.LogError($"Fail to get answers for question:{questionId}, {e.StackTrace}");
        return null;
      }

    }

    public async Task<ICollection<Question>> GetQuestions()
    {
      try
      {
        var questions = await _context.Questions
       .Where(x => x.Deleted == null)
       .ToListAsync();
        return questions;
      }
      catch (Exception e)
      {
        _logger.LogError($"Fail to get questions:{e.StackTrace}");
        return null;
      }

    }
  }
}
