namespace SmartBI.Domain.Entities
{
    public record Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}