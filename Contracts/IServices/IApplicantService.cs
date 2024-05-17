using DTOs.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IServices
{
    public interface IApplicantService
    {
        Task<ApplicantDto> CreateApplication(CreateApplicantDto createApplicantDto);
        Task<ApplicantDto> GetApplication(Guid id);
    }
}
