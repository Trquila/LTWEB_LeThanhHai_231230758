using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public string Slug { get; set; }

        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public string Image { get; set; }
        public string Author { get; set; } = "Admin";

        public bool Status { get; set; } = true;
        public bool Featured { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}