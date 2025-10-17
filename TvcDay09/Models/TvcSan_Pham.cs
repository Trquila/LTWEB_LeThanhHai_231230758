using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvcDay09.Models
{
    [Table("TvcSan_Pham")]
    public class TvcSan_Pham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long tvcID {  get; set; }


        [Display(Name = "Mã sản phẩm")]
        [Required]
        [StringLength(10)]
        public string tvcMaSanPham { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string tvcTenSanPham { get; set; }

        [Display(Name = "Hình ảnh")]
        public string tvcHinhAnh { get; set; }

        [Display(Name = "Số lượng")]
        public int tvcSoLuong { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal tvcDonGia { get; set; }

        public long tvcLoaiSanPhamID { get; set; }
        
        public Tvc_Loai_San_Pham Tvc_Loai_San_Pham { get; set; } //Thuộc tính quan hệ

        //public ICollection<TvcSan_Pham> TvcSan_Phams { get; set; }
    }
}
