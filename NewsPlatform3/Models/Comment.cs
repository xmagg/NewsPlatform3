using System.ComponentModel.DataAnnotations;

namespace NewsPlatform3.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }  // id of a comment
        public int IdArticle { get; set; }
        public Guid IdUser { get; set; }
        public String Content { get; set; }
    }
}
