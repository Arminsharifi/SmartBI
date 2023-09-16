namespace SmartBI.Domain.Entities
{
    public record Transaction
    {
        public long Id { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<TransactionDetail> TransactionDetails { get; set; }
        public DateTime CreationDate { get; set; }

        public Transaction()
        {
            CreationDate = DateTime.Now;
        }
    }
}