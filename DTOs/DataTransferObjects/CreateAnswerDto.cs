using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DataTransferObjects
{
    public record CreateAnswerDto
    {
        public Guid QuestionId { get; init; }
        public string AnswerText { get; init; } = string.Empty;
    }
}
