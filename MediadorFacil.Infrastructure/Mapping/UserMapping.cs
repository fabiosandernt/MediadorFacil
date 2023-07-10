using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MediadorFacil.Domain.Account;

namespace MediadorFacil.Infrastructure.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.UserType).IsRequired();

            builder.OwnsOne(x => x.Password, p =>
            {
                p.Property(f => f.Valor).HasColumnName("Password").IsRequired();
            });

            builder.OwnsOne(x => x.Email, p =>
            {
                p.Property(f => f.Valor).HasColumnName("Email").IsRequired().HasMaxLength(1024);
            });

            builder.HasMany(x => x.Empresas)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId);       

        }
    }
}