using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Answer
    {
    public int AnswerId { get; set; }
    public string AnswerText { get; set; }
    public DateTime? Deleted { get; set; }
    public int QuestionId { get; set; }
    [ForeignKey(nameof(QuestionId))]
    public Question Question { get; set; }
  }
}
