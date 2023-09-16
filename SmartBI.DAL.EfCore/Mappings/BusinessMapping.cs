using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBI.Domain.Entities;

namespace SmartBI.DAL.EfCore.Mappings
{
    public class BusinessMapping : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.ToTable("tbl_business");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Transactions).WithOne(x => x.Business).HasForeignKey(x => x.BusinessId);
            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").IsRequired();
        }
    }
}