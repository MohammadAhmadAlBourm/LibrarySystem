using LibrarySystem.Data;
using LibrarySystem.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using System.Text.Json;

namespace LibrarySystem.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly LibraryDBContext dBContext;

        public BooksController(LibraryDBContext dBContext) 
        {
            this.dBContext = dBContext;
        }

        [HttpGet]
        public IEnumerable<Book> Books()
        {
            var books = dBContext.books.ToList();
            return books;
        }
    }
}
