using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBI.Domain.Entities;

namespace SmartBI.DAL.EfCore.Mappings
{
    public class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("tbl_transaction");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.TransactionDetails).WithOne(x => x.Transaction).HasForeignKey(x => x.TransactionId).OnDelete(DeleteBehavior.Cascade).IsRequired();
            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.BusinessId).HasColumnName("business_id");
            builder.Property(x => x.CustomerId).HasColumnName("customer_id");
            builder.Property(x => x.CreationDate).HasColumnName("creation_date").IsRequired();
        }
    }
}