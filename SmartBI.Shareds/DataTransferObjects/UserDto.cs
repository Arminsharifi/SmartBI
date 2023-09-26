namespace SmartBI.Shareds.DataTransferObjects
{
    public record UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}