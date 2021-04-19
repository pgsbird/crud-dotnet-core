using LegalCasesMicrosservice.Models;
using Microsoft.EntityFrameworkCore;

namespace LegalCasesMicrosservice.Data
{
    public class LegalCaseContext: DbContext
    {
        public LegalCaseContext(DbContextOptions<LegalCaseContext> opt):base(opt)
        {

        }



        public DbSet<LegalCase> LegalCases { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
                    builder.Entity<LegalCase>(entity => {
                        entity.HasIndex(e => e.CaseNumber).IsUnique();
            });
        }

    }
}