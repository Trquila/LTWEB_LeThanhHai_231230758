using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTW_Day0Lab_CodeFirst.Models;

[Table("KhachHang")]
public partial class KhachHang
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public string MaKhachHang { get; set; } = null!;

    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public string HoTenKhachHang { get; set; }

    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public string Email { get; set; }

    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public string MatKhau { get; set; }

    [Required]
    [StringLength(20)]
    [Column(TypeName = "nvarchar(20)")]
    public string DienThoai { get; set; }

    [Required]
    [StringLength(200)]
    [Column(TypeName = "nvarchar(200)")]
    public string DiaChi { get; set; }

    [Required]
    public DateOnly NgayDangKy { get; set; }

    [Required]
    public int TrangThai { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
