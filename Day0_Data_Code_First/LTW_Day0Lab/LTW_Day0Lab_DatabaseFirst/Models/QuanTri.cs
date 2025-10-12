using System;
using System.Collections.Generic;

namespace LTW_Day0Lab_DatabaseFirst.Models;

public partial class QuanTri
{
    public int Id { get; set; }

    public string TaiKhoan { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public int? TrangThai { get; set; }
}
