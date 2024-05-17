using AutoMapper;
using Contracts.IServices;
using DTOs.DataTransferObjects;
using Entities.Models;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.IRepositories;

namespace Services.ServiceImplementation
{
    public class ApplicantService : IApplicantService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ApplicantService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ApplicantDto> CreateApplication(CreateApplicantDto createApplicantDto)
        {
            var applicantEntity = _mapper.Map<Applicant>(createApplicantDto);    
            await _repositoryManager.Applicant.AddAsync(applicantEntity);

            var applicantDto = _mapper.Map<ApplicantDto>(applicantEntity);
            return applicantDto;
        }

        public async Task<ApplicantDto> GetApplication(Guid id)
        {
            var application = await _repositoryManager.Applicant.GetByIdAsync(id);
            if (application is null)
            {
               throw new ApplicantNotFoundException(id.ToString());
            }

            var applicationDto = _mapper.Map<ApplicantDto>(application);
            return applicationDto;
        }
    }
}
