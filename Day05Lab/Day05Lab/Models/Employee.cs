using System.ComponentModel.DataAnnotations;

namespace Day05Lab.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Giới tính không được để trống")]
        [Display(Name = "Giới tính")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lương không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Lương phải lớn hơn 0")]
        [Display(Name = "Lương")]
        public decimal Salary { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; } = true;
    }
}