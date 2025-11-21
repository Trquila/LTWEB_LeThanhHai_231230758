using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Họ tên là bắt buộc")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required(ErrorMessage = "Nội dung là bắt buộc")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        public string Status { get; set; } = "unread";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}