namespace SmartBI.Domain.Entities
{
    public record TransactionDetail
    {
        public long Id { get; set; }
        public int Count { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public long TransactionId { get; set; }
        public Transaction Transaction { get; set; }
    }
}