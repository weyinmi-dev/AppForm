using Contracts.IServices;
using DTOs.DataTransferObjects;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApplicationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerQuestionController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public EmployerQuestionController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "QuestionType: 0 = Paragraph, 1 = yes/no, 2 = dropdown, 3 = multiple-choice, 4 = Date, 5 = number")]
        public async Task<ActionResult<QuestionDto>> PostQuestion(QuestionCreateDto createQuestionDto)
        {
            var createQuestion = await _serviceManager.QuestionService.CreateQuestion(createQuestionDto);
            return CreatedAtAction("GetQuestionId", new { id = createQuestion.Id }, createQuestion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(QuestionUpdateDto questionDto)
        {
           
            await _serviceManager.QuestionService.UpdateQuestion(questionDto);
            return NoContent();
        }

        [HttpGet("collection/({ids})", Name = "AllQuestions")]
        public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestions()
        {
            var questions = await _serviceManager.QuestionService.GetAllQuestions();
            return Ok(questions);
        }

        [HttpGet("{id}", Name = "GetQuestionId")]
        public async Task<ActionResult<QuestionDto>> GetQuestion(Guid id)
        {
            var question = await _serviceManager.QuestionService.GetQuestion(id);

            if (question == null)
            {
                throw new QuestionNotFoundException(id.ToString());
            }
            return question;
        }
    }
}
