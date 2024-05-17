using Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DTOs.DataTransferObjects
{
    public record QuestionCreateDto
    {
        public QuestionType Type { get; init; }
        public string? Text { get; init; } = string.Empty;
        public List<string> Options { get; set; } = new List<string>();
    }
}
