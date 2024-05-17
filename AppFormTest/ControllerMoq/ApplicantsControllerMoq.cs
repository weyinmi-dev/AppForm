using Contracts.IServices;
using DTOs.DataTransferObjects;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceImplementation;

namespace ApplicationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ApplicantsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        public async Task<ActionResult<ApplicantDto>> PostApplication(CreateApplicantDto createApplicationDto)
        {
            var createApplicant = await _serviceManager.ApplicantService.CreateApplication(createApplicationDto);
            return CreatedAtAction(nameof(GetApplication), new { id = createApplicant.Id }, createApplicant);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicantDto>> GetApplication(Guid id)
        {
            var application = await _serviceManager.ApplicantService.GetApplication(id);

            if (application is null)
            {
                throw new ApplicantNotFoundException(id.ToString());
            }

            return application;
        }

        [HttpGet("questions/byType/{questionType}")]
        public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestionsByType(string questionType)
        {
            var questions = await _serviceManager.QuestionService.GetQuestionsByTypeAsync(questionType);
            if (questions == null || !questions.Any())
            {
                return NotFound();
            }
            return Ok(questions);
        }
    }
}
