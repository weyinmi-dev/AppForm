using Contracts.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly CosmosDbContext _repositoryContext;
        private readonly Lazy<IApplicantRepository> _applicantRepository;
        private readonly Lazy<IQuestionRepository> _questionRepository;

        public RepositoryManager(CosmosDbContext repositoryContext, Lazy<IApplicantRepository> applicantRepository, Lazy<IQuestionRepository> questionRepository)
        {
            _repositoryContext = repositoryContext;
            _applicantRepository = applicantRepository;
            _questionRepository = questionRepository;
        }

        public IApplicantRepository Applicant => _applicantRepository.Value;
        public IQuestionRepository Question => _questionRepository.Value;
    }
}
