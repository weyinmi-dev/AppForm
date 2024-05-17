using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ErrorModel
{
    public sealed class ApplicantNotFoundException : NotFoundException
    {
        public ApplicantNotFoundException(string Id) : base($"The applicant with id: {Id} doesn't exist in the database.")
        { 
        }
    }
}
