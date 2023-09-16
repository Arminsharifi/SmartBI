using SmartBI.Shareds.Entities;

namespace SmartBI.AuthService.Domain.Entities
{
    public record User : BaseEntity<int>
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}