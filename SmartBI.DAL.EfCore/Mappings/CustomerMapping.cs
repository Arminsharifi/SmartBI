using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBI.Domain.Entities;

namespace SmartBI.DAL.EfCore.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("tbl_customer");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Transactions).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);
            builder.HasIndex(x => x.PhoneNumber).IsUnique();
            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.FirstName).HasColumnName("first_name").IsRequired();
            builder.Property(x => x.LastName).HasColumnName("last_name").IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnName("phone_number").IsRequired();
        }
    }
}