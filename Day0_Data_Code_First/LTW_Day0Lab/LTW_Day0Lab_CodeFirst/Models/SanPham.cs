using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTW_Day0Lab_CodeFirst.Models;

[Table("SanPham")]
public partial class SanPham
{
    [Key]
    public int Id { get; set; }


    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public string MaSanPham { get; set; } = null!;

    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public string TenSanPham { get; set; }

    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public string HinhAnh { get; set; }

    [Required]
    public int SoLuong { get; set; }

    [Required]
    public float DonGia { get; set; }

    [Required]
    public int MaLoai { get; set; }

    [Required]
    public int TrangThai { get; set; }

    public virtual ICollection<CtHoaDon> CtHoaDons { get; set; } = new List<CtHoaDon>();

    [ForeignKey(nameof(MaLoai))]
    public virtual LoaiSanPham LoaiSanPham { get; set; } = null!;
}
