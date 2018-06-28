using System;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;

namespace Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class QuestionsController : ControllerBase
  {
    private readonly IQuestionAnswerRepository _repository;
    public QuestionsController(IQuestionAnswerRepository repository)
    {
      _repository = repository;
    }
    // GET api/values
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var questions = await _repository.GetQuestions();
      if (questions != null)
      {
        return Ok(questions);
      }
      ModelState.AddModelError("empty", "No results");
      return NotFound();
    }

    // POST api/values
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Question question)
    {
      var isSaved = await _repository.AskQuestion(question);
      if (isSaved)
      {
        return Ok(question);
      }
      ModelState.AddModelError("error", "Could not save question");
      return BadRequest(ModelState);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
