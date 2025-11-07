using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace THLab01.Models
{
    public class Student
    {
        [DisplayName("Mã SV")]
        public int Id { get; set; }

        [DisplayName("Họ tên")]
        [Required(ErrorMessage = "Tên là bắt buộc")]
        public string Name { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        public string Password { get; set; }

        [DisplayName("Ngành học")]
        [Required(ErrorMessage = "Ngành học là bắt buộc")]
        public Branch Branch { get; set; }

        [DisplayName("Giới tính")]
        [Required(ErrorMessage = "Giới tính là bắt buộc")]
        public Gender Gender { get; set; }

        [DisplayName("Hệ đào tạo")]
        public bool IsRegular { get; set; }

        [DisplayName("Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [DisplayName("Ảnh đại diện")]
        public string? Avatar { get; set; }
    }

   
}