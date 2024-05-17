using ApplicationForm.Controllers;
using Contracts.IServices;
using DTOs.DataTransferObjects;
using Moq;
using Services.ServiceImplementation;

namespace ApplicationFormTest
{
    public class ApplicantsControllerTests
    {
        private readonly Mock<IServiceManager> _serviceManagerMock;
        private readonly ApplicantsController _controller;

        public ApplicantsControllerTests()
        {
            _serviceManagerMock = new Mock<IServiceManager>();
            _controller = new ApplicantsController(_serviceManagerMock.Object);
        }

        [Fact]
        public async Task PostApplication_ShouldReturnCreatedAtAction()
        {
            // Arrange
            var createApplicantDto = new CreateApplicantDto { Id = "123", Name = "Test Applicant" };
            _serviceManagerMock.Setup(sm => sm.ApplicantService.CreateApplication(createApplicantDto))
                               .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.PostApplication(createApplicantDto);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(nameof(_controller.GetApplication), actionResult.ActionName);
            Assert.Equal(createApplicantDto.Id, actionResult.RouteValues["id"]);
        }

        [Fact]
        public async Task GetApplication_ValidId_ReturnsApplicant()
        {
            // Arrange
            var applicantDto = new ApplicantDto { Id = "123", Name = "Test Applicant" };
            _serviceManagerMock.Setup(sm => sm.ApplicantService.GetApplication("123"))
                               .ReturnsAsync(applicantDto);

            // Act
            var result = await _controller.GetApplication("123");

            // Assert
            var actionResult = Assert.IsType<ActionResult<ApplicantDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedApplicant = Assert.IsType<ApplicantDto>(okResult.Value);
            Assert.Equal("123", returnedApplicant.Id);
        }

        [Fact]
        public async Task GetApplication_InvalidId_ThrowsApplicantNotFoundException()
        {
            // Arrange
            _serviceManagerMock.Setup(sm => sm.ApplicantService.GetApplication("123"))
                               .ReturnsAsync((ApplicantDto)null);

            // Act & Assert
            await Assert.ThrowsAsync<ApplicantNotFoundException>(() => _controller.GetApplication("123"));
        }

        [Fact]
        public async Task GetQuestionsByType_ValidType_ReturnsQuestions()
        {
            // Arrange
            var questions = new List<QuestionDto>
        {
            new QuestionDto { Id = "1", QuestionType = "YesNo", QuestionText = "Is this a test?" },
            new QuestionDto { Id = "2", QuestionType = "YesNo", QuestionText = "Is this another test?" }
        };
            _serviceManagerMock.Setup(sm => sm.QuestionService.GetQuestionsByTypeAsync("YesNo"))
                               .ReturnsAsync(questions);

            // Act
            var result = await _controller.GetQuestionsByType("YesNo");

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<QuestionDto>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedQuestions = Assert.IsAssignableFrom<IEnumerable<QuestionDto>>(okResult.Value);
            Assert.Equal(2, returnedQuestions.Count());
        }

        [Fact]
        public async Task GetQuestionsByType_InvalidType_ReturnsNotFound()
        {
            // Arrange
            _serviceManagerMock.Setup(sm => sm.QuestionService.GetQuestionsByTypeAsync("InvalidType"))
                               .ReturnsAsync((IEnumerable<QuestionDto>)null);

            // Act
            var result = await _controller.GetQuestionsByType("InvalidType");

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<QuestionDto>>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }
    }

}