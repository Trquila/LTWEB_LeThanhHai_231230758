using System;
using System.Collections.Generic;

namespace LTW_Day0Lab_DatabaseFirst.Models;

public partial class KhachHang
{
    public int Id { get; set; }

    public string MaKhachHang { get; set; } = null!;

    public string? HoTenKhachHang { get; set; }

    public string? Email { get; set; }

    public string? MatKhau { get; set; }

    public string? DienThoai { get; set; }

    public string? DiaChi { get; set; }

    public DateOnly? NgayDangKy { get; set; }

    public int? TrangThai { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
