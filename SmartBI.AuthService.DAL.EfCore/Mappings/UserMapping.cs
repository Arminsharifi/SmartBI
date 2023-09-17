using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBI.AuthService.Domain.Entities;

namespace SmartBI.AuthService.DAL.EfCore.Mappings
{
    internal class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tbl_user");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(150).IsRequired();
            builder.Property(x => x.UserName).HasColumnName("user_name").HasMaxLength(70).IsRequired();
            builder.Property(x => x.Password).HasColumnName("password").IsRequired();
            builder.Property(x => x.Salt).HasColumnName("salt").IsRequired();
            builder.Property(x => x.CreationDate).HasColumnName("creation_date").IsRequired();
        }
    }
}