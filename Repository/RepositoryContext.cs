using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    //public class RepositoryContext : IdentityDbContext<AppUser>
    //{
        
    //    public RepositoryContext(DbContextOptions options) : base(options)
    //    {

    //    }

    //    public DbSet<Applicant>? Applicants { get; set; }
    //    public DbSet<Question>? Question { get; set; }
    //    public DbSet<Employer>? Employers { get; set; }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Question>().Property(q => q.Options)
    //            .HasConversion(
    //                v => string.Join(',', v),
    //                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
    //            );
    //    }


    //}
}
