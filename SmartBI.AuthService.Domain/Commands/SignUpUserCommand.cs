using System.ComponentModel.DataAnnotations;

namespace SmartBI.AuthService.Domain.Commands
{
    public record SignUpUserCommand
    {
        [Required]
        [MinLength(2)]
        [MaxLength(150)]
        public string Name { get; set; }
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