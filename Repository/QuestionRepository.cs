using Contracts.IRepositories;
using DTOs.DataTransferObjects;
using Entities.Enums;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(CosmosDbContext dbContext)
         : base(dbContext, "QuestionContainer")
        {

        }

        public async Task<IEnumerable<Question>> GetQuestionsByTypeAsync(string questionType)
        {
            return await GetEntitiesByTypeAsync("questionType", questionType);
        }
    }
}
