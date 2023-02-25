using LibrarySystem.Data;
using LibrarySystem.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    public class DropDownController : Controller
    {
        private readonly LibraryDBContext dBContext;

        public DropDownController(LibraryDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public IActionResult Index()
        {

            ViewBag.Authors = GetAuthors();
            ViewBag.Books = GetBooks();
            return View();
        }



        public List<Author> GetAuthors()
        {
            var authors = dBContext.authors.ToList();
            var authorList = new List<Author>();

            foreach (var item in authors)
            {
                Author author = new Author();
                author.Id = item.Id;
                author.FirstName = item.FirstName;
                author.LastName = item.LastName;
                authorList.Add(author);
            }

            return authorList;
        }

        public List<Book> GetBooks()
        {
            //string Sp = "exce dbo.GET_BookList";
            //var books = dBContext.Database.SqlQuery<Book>(Sp).ToList();

            var books = dBContext.books.ToList();

            //
            var bookList = new List<Book>();

            foreach (var item in books)
            {
                Book book = new Book();

                book.Id = item.Id;
                book.Title = item.Title;
                book.PublishDate = item.PublishDate;
                book.ISBN = item.ISBN;
                book.Publisher = item.Publisher;
                book.AuthorID = item.AuthorID;

                bookList.Add(book);
            }

            return bookList;
        }

        public JsonResult GetFilteredData(Guid AuthorID)
        {
            var data = GetBooks().Where(p => p.AuthorID == AuthorID).ToList();
            return Json(data);
        }

    }
}
