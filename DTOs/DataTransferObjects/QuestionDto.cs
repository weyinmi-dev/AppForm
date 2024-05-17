using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DataTransferObjects
{
    public record QuestionDto
    {
        public Guid Id { get; init; }
        public QuestionType Type { get; init; }
        public string? Text { get; init; } = string.Empty;
        public List<string> Options { get; init; } = new List<string>();
    }
}
