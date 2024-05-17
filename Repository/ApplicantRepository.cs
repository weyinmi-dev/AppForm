using Contracts.IRepositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ApplicantRepository : RepositoryBase<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(CosmosDbContext dbContext)
         : base(dbContext, "ApplicantContainer")
        {

        }
    }
}
