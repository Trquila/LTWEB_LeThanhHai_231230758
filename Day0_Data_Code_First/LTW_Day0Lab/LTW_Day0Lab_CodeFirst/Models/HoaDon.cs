using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTW_Day0Lab_CodeFirst.Models;

[Table("HoaDon")]
public partial class HoaDon
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public string MaHoaDon { get; set; } = null!;

    [Required]
    public int MaKhachHang { get; set; }

    [Required]
    public DateOnly NgayHoaDon { get; set; }

    [Required]
    public DateOnly NgayNhan { get; set; }

    [Required]
    [StringLength (100)]
    [Column(TypeName = "nvarchar(100)")]
    public string HoTenKhachHang { get; set; }

    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public string Email { get; set; }

    [Required]
    [StringLength(20)]
    [Column(TypeName = "nvarchar(20)")]
    public string DienThoai { get; set; }

    [Required]
    [StringLength(200)]
    [Column(TypeName = "nvarchar(200)")]
    public string DiaChi { get; set; }

    [Required]
    public float TongTriGia { get; set; }

    [Required]
    public int TrangThai { get; set; }

    public virtual ICollection<CtHoaDon> CtHoaDons { get; set; } = new List<CtHoaDon>();

    [ForeignKey(nameof(MaKhachHang))]
    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;
}
