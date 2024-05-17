using ApplicationForm.Controllers;
using Contracts.IServices;
using DTOs.DataTransferObjects;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationForm.Tests
{
    public class EmployerQuestionControllerTests
    {
        private readonly Mock<IServiceManager> _serviceManagerMock;
        private readonly EmployerQuestionController _controller;

        public EmployerQuestionControllerTests()
        {
            _serviceManagerMock = new Mock<IServiceManager>();
            _controller = new EmployerQuestionController(_serviceManagerMock.Object);
        }

        [Fact]
        public async Task PostQuestion_ShouldReturnCreatedAtAction()
        {
            // Arrange
            var createQuestionDto = new QuestionCreateDto { Text = "Sample Question", Type = Entities.Enums.QuestionType.YesNo };
            var questionDto = new QuestionDto { Id = Guid.NewGuid(), Text = "Sample Question", Type = Entities.Enums.QuestionType.YesNo };

            _serviceManagerMock.Setup(sm => sm.QuestionService.CreateQuestion(createQuestionDto))
                               .ReturnsAsync(questionDto);

            // Act
            var result = await _controller.PostQuestion(createQuestionDto);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal("GetQuestionId", actionResult.ActionName);
            Assert.Equal(questionDto.Id, actionResult.RouteValues["id"]);
            Assert.Equal(questionDto, actionResult.Value);
        }

        [Fact]
        public async Task PutQuestion_ShouldReturnNoContent()
        {
            // Arrange
            var questionUpdateDto = new QuestionUpdateDto { Id = Guid.NewGuid(), Text = "Updated Question", Type = Entities.Enums.QuestionType.YesNo };

            _serviceManagerMock.Setup(sm => sm.QuestionService.UpdateQuestion(questionUpdateDto))
                               .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.PutQuestion(questionUpdateDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetQuestions_ShouldReturnAllQuestions()
        {
            // Arrange
            var questions = new List<QuestionDto>
            {
                new QuestionDto { Id = Guid.NewGuid(), Type = Entities.Enums.QuestionType.YesNo, Text = "Is this a test?" },
                new QuestionDto { Id = Guid.NewGuid(), Type = Entities.Enums.QuestionType.Paragraph, Text = "Describe yourself." }
            };

            _serviceManagerMock.Setup(sm => sm.QuestionService.GetAllQuestions())
                               .ReturnsAsync(questions);

            // Act
            var result = await _controller.GetQuestions();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<QuestionDto>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedQuestions = Assert.IsAssignableFrom<IEnumerable<QuestionDto>>(okResult.Value);
            Assert.Equal(2, returnedQuestions.Count());
        }
        [Fact]
        public async Task GetQuestion_ValidId_ReturnsQuestion()
        {
            // Arrange
            var questionDto = new QuestionDto { Id = Guid.NewGuid(), Type = Entities.Enums.QuestionType.YesNo, Text = "Are you above 18?" };

            _serviceManagerMock.Setup(sm => sm.QuestionService.GetQuestion(questionDto.Id))
                               .ReturnsAsync(questionDto);

            // Act
            var result = await _controller.GetQuestion(questionDto.Id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<QuestionDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedQuestion = Assert.IsType<QuestionDto>(okResult.Value);
            Assert.Equal(questionDto.Id, returnedQuestion.Id);
            Assert.Equal(questionDto.Type, returnedQuestion.Type);
            Assert.Equal(questionDto.Text, returnedQuestion.Text);
        }

        [Fact]
        public async Task GetQuestion_InvalidId_ThrowsQuestionNotFoundException()
        {
            // Arrange
            var invalidId = Guid.NewGuid();

            _serviceManagerMock.Setup(sm => sm.QuestionService.GetQuestion(invalidId))
                               .ReturnsAsync((QuestionDto)null);

            // Act & Assert
            await Assert.ThrowsAsync<QuestionNotFoundException>(() => _controller.GetQuestion(invalidId));
        }
    }
}
