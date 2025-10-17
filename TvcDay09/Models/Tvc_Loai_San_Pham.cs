using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore; // thêm namespace này để dùng [Index]

namespace TvcDay09.Models
{
    [Table("TvcLoai_San_Pham")]
    [Index(nameof(tvcMaLoai), IsUnique = true)] // <--- Đặt unique index
    public class Tvc_Loai_San_Pham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long tvcId { get; set; }

        [Display(Name = "Mã loại")]
        [StringLength(50)]
        public string tvcMaLoai { get; set; }

        [Display(Name = "Tên loại")]
        public string tvcTenLoai { get; set; }

        [Display(Name = "Trạng thái")]
        public bool tvcTrangThai { get; set; }

        public ICollection<TvcSan_Pham> tvcSan_Phams { get; set; }
    }
}
