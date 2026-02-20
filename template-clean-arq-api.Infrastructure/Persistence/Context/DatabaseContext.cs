using Microsoft.EntityFrameworkCore;
using template_clean_arq_api.Domain.Entities;
using template_clean_arq_api.Infrastructure.Persistence.DataBaseConfigurations;

namespace template_clean_arq_api.Infrastructure.Persistence.Context
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> context) : DbContext(context)
    {
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        }
    }
}
