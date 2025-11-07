using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using THLab01.Models;

namespace THLab01.Controllers
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() as DescriptionAttribute;
            return attribute?.Description ?? value.ToString();
        }
    }
    public class StudentController : Controller
    {   

        private static List<Student> ListStudents = new List<Student>
        {
            new Student {
                Id = 101,
                Name = "Adam",
                Branch = Branch.IT,
                Gender = Gender.Male,
                IsRegular = true,
                Address = "A001",
                Email = "adam@example.com",
                DateOfBirth = new DateTime(2000, 1, 1)
            },
            new Student {
                Id = 102,
                Name = "Alice",
                Branch = Branch.BE,
                Gender = Gender.Female,
                IsRegular = true,
                Address = "A002",
                Email = "alice@example.com",
                DateOfBirth = new DateTime(2000, 2, 1)
            },
        };

        [Route("Admin/Student/List")]
        public IActionResult Index()
        {
            return View(ListStudents);
        }

        [HttpGet]
        [Route("Admin/Student/Add")]
        public IActionResult Create()
        {
            SetupViewBags();
            return View();
        }

        [HttpPost]
        [Route("Admin/Student/Add")]
        public IActionResult Create(Student s, IFormFile avatar)
        {
            if (ModelState.IsValid)
            {
                // Xử lý upload ảnh
                if (avatar != null && avatar.Length > 0)
                {
                    s.Avatar = UploadAvatar(avatar);
                }

                // Thêm sinh viên mới
                if (ListStudents.Any())
                {
                    s.Id = ListStudents.Max(st => st.Id) + 1;
                }
                else
                {
                    s.Id = 1;
                }

                ListStudents.Add(s);
                return RedirectToAction("Index");
            }

            SetupViewBags();
            return View(s);
        }

        private string UploadAvatar(IFormFile avatar)
        {
            // Tạo thư mục nếu chưa tồn tại
            var imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            // Tạo tên file unique
            var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(avatar.FileName)}";
            var filePath = Path.Combine(imagesFolder, fileName);

            // Lưu file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                avatar.CopyTo(stream);
            }

            return fileName;
        }

        private void SetupViewBags()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender))
                .Cast<Gender>()
                .Select(g => new SelectListItem
                {
                    Text = g.ToString(),
                    Value = g.ToString()
                })
                .ToList();

            ViewBag.AllBranches = Enum.GetValues(typeof(Branch))
                .Cast<Branch>()
                .Select(b => new SelectListItem
                {
                    Text = b.ToString(),
                    Value = b.ToString()
                })
                .ToList();
        }

    }
}