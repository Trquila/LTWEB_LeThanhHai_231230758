using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeThanhHai_231230758_de02.Models
{
    public class HvtCatalog
    {
        [Key]
        public int hvtId { get; set; }

        [Required]
        [StringLength(200)]
        public string hvtCateName { get; set; } = string.Empty;

        [Required]
        [Range(100, 5000, ErrorMessage = "Price must be between 100 and 5000.")]
        public decimal hvtCatePrice { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int hvtCateQty { get; set; }

        [StringLength(255)]
        [RegularExpression(@"(?i)^.*\.(jpg|png|gif|tiff)$", ErrorMessage = "Ảnh phải có đuôi: .jpg .png .gif .tiff")]
        public string hvtPicture { get; set; } = string.Empty;

        [Required]
        public bool hvtCateActive { get; set; }
    }
}
