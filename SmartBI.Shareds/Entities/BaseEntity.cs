namespace SmartBI.Shareds.Entities
{
    public abstract record BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreationDate { get; set; }

        public BaseEntity()
        {
            CreationDate = DateTime.UtcNow;
        }
    }
}