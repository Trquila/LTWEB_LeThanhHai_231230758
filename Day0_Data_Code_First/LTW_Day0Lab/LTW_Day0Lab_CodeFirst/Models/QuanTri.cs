using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTW_Day0Lab_CodeFirst.Models;

[Table("QuanTri")]
public partial class QuanTri
{
    [Key]
    public int Id { get; set; }


    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public string TaiKhoan { get; set; } = null!;

    [Required]
    [StringLength(100)]
    [Column(TypeName = "nvarchar(100)")]
    public string MatKhau { get; set; } = null!;

    [Required]
    public int? TrangThai { get; set; }
}
