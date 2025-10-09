using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebLab3.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Summary { get; set; }

        // Phương thức lấy danh sách sách
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book(){
                    Id = 1,
                    Title = "Đắc Nhân Tâm",
                    AuthorId = 1,
                    GenreId = 2,
                    Image = "dacnhantam.jpg",
                    Price = 80000,
                    TotalPage = 320,
                    Summary = "Sách hay về kỹ năng giao tiếp"
                },
                new Book(){
                    Id = 2,
                    Title = "Nhà Giả Kim",
                    AuthorId = 2,
                    GenreId = 3,
                    Image = "nhagiakim.jpg",
                    Price = 75000,
                    TotalPage = 200,
                    Summary = "Câu chuyện về hành trình theo đuổi ước mơ"
                },
                new Book(){
                    Id = 3,
                    Title = "Sherlock Holmes",
                    AuthorId = 3,
                    GenreId = 5,
                    Image = "sherlockholmes.jpg",
                    Price = 175000,
                    TotalPage = 200,
                    Summary = "Sách về trinh thám thú vị"
                },
                new Book(){
                    Id = 4,
                    Title = "A brief history of time",
                    AuthorId = 4,
                    GenreId = 5,
                    Image = "luocsuthoigian.jpg",
                    Price = 175000,
                    TotalPage = 200,
                    Summary = "Sách về lịch sử vũ trụ"
                }
            };
            return books;
        }

        // Phương thức lấy sách theo ID
        public Book GetBookById(int id)
        {
            Book book = this.GetBookList().FirstOrDefault(b => b.Id == id);
            return book;
        }

        // Danh sách tác giả cho ComboBox
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Dale Carnegie" },
            new SelectListItem { Value = "2", Text = "Paulo Coelho" },
            new SelectListItem { Value = "3", Text = "Arthur Conan Doyle" },
            new SelectListItem { Value = "4", Text = "Stephen Hawking" }
        };

        // Danh sách thể loại cho ComboBox
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Truyện tranh" },
            new SelectListItem { Value = "2", Text = "Văn học đương đại" },
            new SelectListItem { Value = "3", Text = "Kỹ năng sống" },
            new SelectListItem { Value = "4", Text = "Truyện ngắn" },
            new SelectListItem { Value = "5", Text = "Tiểu thuyết" }
        };
    }
}