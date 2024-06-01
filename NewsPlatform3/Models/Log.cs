using System.ComponentModel.DataAnnotations;

namespace NewsPlatform3.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; }

        public string Date { get; set; }

        public string Description { get; set; }
    }
}
