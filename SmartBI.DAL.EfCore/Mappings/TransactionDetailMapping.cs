using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBI.Domain.Entities;

namespace SmartBI.DAL.EfCore.Mappings
{
    public class TransactionDetailMapping : IEntityTypeConfiguration<TransactionDetail>
    {
        public void Configure(EntityTypeBuilder<TransactionDetail> builder)
        {
            builder.ToTable("tbl_transaction_detail");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Food).WithMany().HasForeignKey(x => x.FoodId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.Count).HasColumnName("count").IsRequired();
            builder.Property(x => x.FoodId).HasColumnName("food_id").IsRequired();
            builder.Property(x => x.TransactionId).HasColumnName("transaction_id").IsRequired();
        }
    }
}