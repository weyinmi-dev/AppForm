using DTOs.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IServices
{
    public interface IQuestionService
    {
        Task<QuestionDto> CreateQuestion(QuestionCreateDto questionCreateDto);
        Task UpdateQuestion(QuestionUpdateDto questionDto);
        Task<IEnumerable<QuestionDto>> GetAllQuestions();
        Task<QuestionDto> GetQuestion(Guid id);
        Task<bool> QuestionExists(Guid id);
        Task<IEnumerable<QuestionDto>> GetQuestionsByTypeAsync(string questionType);
    }
}
