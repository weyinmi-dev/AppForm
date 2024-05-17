using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ErrorModel
{
    public sealed class IdMismatchBadRequestException : BadRequestException
    {
        public IdMismatchBadRequestException() : base("There is a mismatch of the Id parameter")
        {

        }
    }
}
