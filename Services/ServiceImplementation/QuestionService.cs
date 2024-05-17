using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices;
using DTOs.DataTransferObjects;
using Entities.ErrorModel;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceImplementation
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public QuestionService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<QuestionDto> CreateQuestion(QuestionCreateDto questionCreateDto)
        {
            var question = _mapper.Map<Question>(questionCreateDto);
            await _repositoryManager.Question.AddAsync(question);
            var questionDto = _mapper.Map<QuestionDto>(question);
            return questionDto;
        }

        public async Task<IEnumerable<QuestionDto>> GetAllQuestions()
        {
            var questions = await _repositoryManager.Question.GetAllAsync();
            var questionDtos = _mapper.Map<IEnumerable<QuestionDto>>(questions);
            return questionDtos;
        }

        public async Task<QuestionDto> GetQuestion(Guid id)
        {
            var question = await _repositoryManager.Question.GetByIdAsync(id);

            if(question is null)
            {
                throw new QuestionNotFoundException(id.ToString());
            }
            var questionDto = _mapper.Map<QuestionDto>(question);
            return questionDto;
        }

        public async Task<bool> QuestionExists(Guid id)
        {
            var questionExist = await _repositoryManager.Question.GetByIdAsync(id);
            return questionExist != null;
        }

        public async Task UpdateQuestion(QuestionUpdateDto questionDto)
        {
            if (questionDto.Id == Guid.Empty)
            {
                throw new BadRequestException("QuestionId is invalid");
            }
            var question = _mapper.Map<Question>(questionDto);
            await _repositoryManager.Question.UpdateAsync(question);
            

            if (!await QuestionExists(questionDto.Id))
            {
                throw new QuestionNotFoundException(questionDto.Id.ToString());
            }
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestionsByTypeAsync(string questionType)
        {
            var questions = await _repositoryManager.Question.GetQuestionsByTypeAsync(questionType);
            if (questions is null)
            {
                throw new QuestionNotFoundException(questionType);
            }
            return _mapper.Map<IEnumerable<QuestionDto>>(questions);
        }
    }
}
