using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;

namespace Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnswersController : ControllerBase
  {
    private readonly IQuestionAnswerRepository _repository;
    public AnswersController(IQuestionAnswerRepository repository)
    {
      _repository = repository;
    }

    [HttpGet("{questionId}")]
    public async Task<IActionResult> GetAnswersForQuestion(int questionId)
    {
      var answers = await _repository.GetAnswers(questionId);
      if (answers != null)
      {
        return Ok(answers);
      }
      ModelState.AddModelError("empty", "No results");
      return NotFound(ModelState);
    }

    // POST api/values
    [HttpPost()]
    public async Task<IActionResult> Post([FromBody] Answer answer)
    {
      var ok = await _repository.AnswerQuestion(answer);
      if (ok)
      {
        return Ok();
      }
      ModelState.AddModelError("error", "Could not save answer");
      return NotFound(ModelState);
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
