using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Applicant
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public ICollection<Answer>? Answers { get; set; }

    }
}
