using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Models
{
    public class Setting
    {
        [Key]
        [StringLength(100)]
        public string Key { get; set; }

        public string Value { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}