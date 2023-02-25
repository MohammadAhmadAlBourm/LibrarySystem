using LibrarySystem.Data;
using LibrarySystem.Models.Domain;
using LibrarySystem.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryDBContext dBContext;

        public BooksController(LibraryDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            ViewBag.Authors = GetAuthors();
            return View();
        }
        public IActionResult Index()
        {
            try
            {
                var books = dBContext.books.ToList();

                //string Sp = "EXEC [dbo].[GET_Books] ";
                //var books = dBContext.Database.SqlQuery<Book>(Sp).ToList();

                return View(books);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region
        [HttpPost]
        public async Task<IActionResult> AddBook(BookViewModel model)
        {
            try
            {
                if (model != null)
                {
                    var book = new Book()
                    {
                        Id = Guid.NewGuid(),
                        Title = model.title,
                        Publisher = model.publisher,
                        PublishDate = model.publish_date,
                        ISBN = model.isbn,
                        AuthorID = model.author_id,
                    };

                    await dBContext.books.AddAsync(book);
                    await dBContext.SaveChangesAsync();
                }
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        [HttpPost]
        public IActionResult DeleteBook(BookViewModel model)
        {
            try
            {
                var book = dBContext.books.Where(x => x.Id == model.id).FirstOrDefault();
                if (book != null)
                {
                    dBContext.books.Remove(book);
                    dBContext.SaveChanges();

                    return RedirectToAction("index");
                }
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                Book book= new Book();

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

        public JsonResult GetFilteredData(Guid author_id)
        {
            var data = GetBooks().Where(p => p.AuthorID == author_id).ToList();
            return Json(data);
        }
    }
}
