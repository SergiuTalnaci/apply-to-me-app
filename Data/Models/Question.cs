using System;
using System.Collections.Generic;

namespace Data.Models
{
  public class Question
  {
    public int QuestionId { get; set; }
    public string QuestionText { get; set; }
    public DateTime? Deleted { get; set; }
    public ICollection<Answer> Answer { get; set; } = new HashSet<Answer>();
  }
}
