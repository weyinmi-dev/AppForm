using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ErrorModel
{
    public sealed class QuestionNotFoundException : NotFoundException
    {
        public QuestionNotFoundException(string questionId) : base($"The question with id: {questionId} doesn't exist in the database.")
        { 
        }
    }
}
