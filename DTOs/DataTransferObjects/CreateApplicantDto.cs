using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DataTransferObjects
{
    public record CreateApplicantDto
    {
        public Guid Id { get; init; }
        public List<CreateAnswerDto> Answers { get; init; } = new List<CreateAnswerDto>();
    }
}
