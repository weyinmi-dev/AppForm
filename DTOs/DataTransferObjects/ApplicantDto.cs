using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DataTransferObjects
{
    public record ApplicantDto
    {
        public Guid Id { get; init; }
        public ICollection<AnswerDto>? Answers { get; init; }
    }
}
