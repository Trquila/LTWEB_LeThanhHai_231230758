using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTW_Day0Lab_CodeFirst.Models;

[Table("LoaiSanPham")]
public partial class LoaiSanPham
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public string MaLoai { get; set; } = null!;

    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public string TenLoai { get; set; }

    [Required]
    public int TrangThai { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; }
}
