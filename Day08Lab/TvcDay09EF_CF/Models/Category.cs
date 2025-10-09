using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvcDay09EF_CF.Models
{

    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        [Required(ErrorMessage ="Tên danh mục không được để trống")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName ="TinyInt")]
        public byte Status { get; set; }

        public DateTime CreateDate { get; set; }

        public ICollection<Product> products { get; set; }
        public Category()
        {

        }

    }
}
