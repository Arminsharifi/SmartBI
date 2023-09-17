using System.ComponentModel.DataAnnotations;

namespace SmartBI.AuthService.Domain.Queries
{
    public record SignInUserQuery
    {
        [Required]
        [MinLength(5)]
        [MaxLength(70)]
        public string UserName { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        public string Password { get; set; }
    }
}