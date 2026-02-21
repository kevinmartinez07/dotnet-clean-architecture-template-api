using Microsoft.EntityFrameworkCore;
using template_clean_arq_api.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace template_clean_arq_api.Infrastructure.Persistence.DataBaseConfigurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(e => e.Id).HasName("users_pkey");


            builder.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");

            builder.Property(d => d.Name).HasColumnName("name");

            builder.Property(d => d.Email).HasColumnName("email");

            builder.Property(d => d.Password).HasColumnName("password");

            builder.Property(d => d.PhoneNumber).HasColumnName("phone_number");

            builder.Property(e => e.CountryId).HasColumnName("country_id");   

            builder.Property(e => e.StatusId).HasColumnName("status_id");

        }
    }
}
