using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvcDay09EF_CF.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(150, ErrorMessage = "Tên sản phẩm giới hạn 150 ký tự")]
        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Image { get; set; }

        [Required(ErrorMessage ="Giá sản phẩm không được để trống")]
        public int Price { get; set; }
        public float SalePrice {  get; set; }
        public byte Status { get; set; }
        [StringLength(1000, ErrorMessage = "Nội dung mô tả giới hạn 1000 ký tự")]
        [Column(TypeName = "ntext")]
        public string Description {  get; set; }

       
        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage ="Danh mục sản phẩm không được để trống")]
        public int CategoryId {  get; set; }
        public Category Category { get; set; }

    }
}
