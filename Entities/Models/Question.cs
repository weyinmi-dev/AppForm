using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public QuestionType Type { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new List<string>();
    }
}
