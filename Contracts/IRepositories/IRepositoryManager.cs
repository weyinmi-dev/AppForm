using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IRepositories
{
    public interface IRepositoryManager
    {
        IApplicantRepository Applicant { get; }
        IQuestionRepository Question { get; }
    }
}
