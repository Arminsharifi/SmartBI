namespace SmartBI.Domain.Entities
{
    public record Business
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
}