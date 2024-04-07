using System.ComponentModel.DataAnnotations;

namespace NewsPlatform3.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required] 
        public string Password { get; set; }
        public int Level { get; set; }
    }
}
