using System.ComponentModel.DataAnnotations;

namespace NewsPlatform3.Models
{
    public class Article
    {
        [Key]   
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
