using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTW_Day0Lab_CodeFirst.Models;

[Table("CtHoaDon")]
public partial class CtHoaDon
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int HoaDonId { get; set; }

    [Required]
    public int SanPhamId { get; set; }

    [Required]
    public int SoLuongMua { get; set; }

    [Required]
    public float DonGiaMua { get; set; }

    [Required]
    public float ThanhTien { get; set; }

    [Required]
    public int TrangThai { get; set; }

    [ForeignKey(nameof(HoaDonId))]
    public virtual HoaDon HoaDon { get; set; } = null!;

    [ForeignKey(nameof(SanPhamId))]
    public virtual SanPham SanPham { get; set; } = null!;
}
