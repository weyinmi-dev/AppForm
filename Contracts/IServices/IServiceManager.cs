using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IServices
{
    public interface IServiceManager
    {
        IQuestionService QuestionService { get; }
        IApplicantService ApplicantService { get; }
    }
}
