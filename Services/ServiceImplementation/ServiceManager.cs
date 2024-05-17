using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceImplementation
{
    public sealed class ServiceManager : IServiceManager
    {
        private IRepositoryManager _repositoryManager;
        private readonly Lazy<IApplicantService> _applicantService;
        private readonly Lazy<IQuestionService> _questionService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper) 
        {
            _applicantService = new Lazy<IApplicantService>(() => new ApplicantService(repositoryManager, logger, mapper));

            _questionService = new Lazy<IQuestionService>(() => new QuestionService(repositoryManager, logger, mapper));
        }

        public IQuestionService QuestionService => _questionService.Value;

        public IApplicantService ApplicantService => _applicantService.Value;
    }
}
