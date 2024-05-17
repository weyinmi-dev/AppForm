using ApplicationForm.Controllers;
using Contracts.IServices;
using DTOs.DataTransferObjects;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationForm.Tests
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
        public async Task GetApplication_InvalidId_ThrowsApplicantNotFoundException()
        {
            // Arrange
            var invalidId = Guid.NewGuid();
            _serviceManagerMock.Setup(sm => sm.ApplicantService.GetApplication(invalidId))
                               .ReturnsAsync((ApplicantDto)null);

            // Act & Assert
            await Assert.ThrowsAsync<ApplicantNotFoundException>(() => _controller.GetApplication(invalidId));
        }

        [Fact]
        public async Task GetQuestionsByType_ValidType_ReturnsQuestions()
        {
            // Arrange
            var questions = new List<QuestionDto>
            {
                new QuestionDto { Id = Guid.NewGuid(), Type = Entities.Enums.QuestionType.YesNo, Text = "Is this a test?" },
                new QuestionDto { Id = Guid.NewGuid(), Type = Entities.Enums.QuestionType.YesNo, Text = "Is this another test?" }
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
