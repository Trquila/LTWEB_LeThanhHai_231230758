using DayLabTh2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace DayLabTh2.Controllers
{
    [Route("Admin/[controller]")]
    public class StudentController : Controller
    {


        private List<Student> listStudens = new List<Student>();

        
        public StudentController()
        {
            listStudens = new List<Student>()
            {
                new Student() { Id = 101 , Name = "Hải Nam", Branch = Branch.IT,
                Gender = Gender.Male, IsRegular=true,
                Address="A1-2018", Email = "nam@g.com"
                },
                 new Student() { Id = 102 , Name = "Minh Tú", Branch = Branch.IT,
                Gender = Gender.Male, IsRegular=true,
                Address="A1-2019", Email = "tu@g.com"
                },
                  new Student() { Id = 103 , Name = "Hoàng Phong", Branch = Branch.IT,
                Gender = Gender.Male, IsRegular=false,
                Address="A1-2020", Email = "phong@g.com"
                },
                   new Student() { Id = 104 , Name = "Xuân Mai", Branch = Branch.IT,
                Gender = Gender.Male, IsRegular=false,
                Address="A1-2021", Email = "mai@g.com"
                },
            };
        }
        [Route("List")]
        public IActionResult Index()
        {
            return View(listStudens);
        }


        [HttpGet]
        [Route("Add")]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender))
                             .Cast<Gender>()
                             .Select(g => g.ToString());
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem{ Text ="IT" , Value ="1"},
                new SelectListItem{ Text ="BE" , Value ="2"},
                new SelectListItem{ Text ="CE" , Value ="3"},
                new SelectListItem{ Text ="EE" , Value ="4"}
            };
            return View();
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Create(Student s ,IFormFile? AvatarFile)
        {
            s.Id = listStudens.Last<Student>().Id+1;
            if (AvatarFile != null && AvatarFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                string uniqueFileName = $"{Guid.NewGuid()}_{AvatarFile.FileName}";
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    AvatarFile.CopyTo(stream);
                }

                // Lưu tên file vào model
                s.Avatar = uniqueFileName;
            }
            listStudens.Add(s);
            return View("Index", listStudens);
        }

    }
}
