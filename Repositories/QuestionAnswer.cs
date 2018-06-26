using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories
{
  public class QuestionAnswerRepository : IQuestionAnswerRepository
  {
    private readonly AppDb _context;
    public QuestionAnswerRepository(AppDb context)
    {
      _context = context;
    }
    public async Task AnswerQuestion(Answer answer)
    {
      _context.Answers.Add(answer);
      await _context.SaveChangesAsync();
    }

    public async Task AskQuestion(Question question)
    {
      _context.Questions.Add(question);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAnswer(int answerId)
    {
      var answer = await _context.Answers.FirstOrDefaultAsync(x => x.AnswerId == answerId);
      if (answer == null) return;
      answer.Deleted = DateTime.Now;
      await _context.SaveChangesAsync();
    }

    public async Task DeleteQuestion(int questionId)
    {
      var question = await _context.Questions.FirstOrDefaultAsync(x => x.QuestionId == questionId);
      if (question == null) return;
      var answers = await _context.Answers.Where(x => x.QuestionId == questionId).ToListAsync();
      answers.ForEach(x => x.Deleted = DateTime.Now);
      question.Deleted = DateTime.Now;
      await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Answer>> GetAnswers(int questionId)
    {
      var answers = await _context.Answers
        .Where(x => x.QuestionId == questionId)
        .Where(x => x.Deleted == null)
        .ToListAsync();
      return answers;
    }

    public async Task<ICollection<Question>> GetQuestions()
    {
      var questions = await _context.Questions
        .Where(x => x.Deleted == null)
        .ToListAsync();
      return questions;
    }
  }
}
