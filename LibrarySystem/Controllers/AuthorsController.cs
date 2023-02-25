using LibrarySystem.Data;
using LibrarySystem.Models.Domain;
using LibrarySystem.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibrarySystem.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly LibraryDBContext dBContext;

        public AuthorsController(LibraryDBContext dBContext) 
        {
            this.dBContext = dBContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> index() 
        {
            try
            {
                var authors = await dBContext.authors.ToListAsync();

                return View(authors);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult ViewAuthor(Guid id)
        {
            try
            {
                var author = dBContext.authors.Where(x => x.Id == id).FirstOrDefault();
                
                if (author != null)
                {
                    var viewModel = new AuthorViewModel()
                    {
                        id = author.Id,
                        first_name = author.FirstName,
                        last_name = author.LastName,
                    };
                    return View(viewModel);
                }
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        public IActionResult ViewAuthor(AuthorViewModel model)
        {
            try
            {
                var author = dBContext.authors.Where(x => x.Id == model.id).FirstOrDefault();

                if (author != null)
                {
                    author.FirstName = model.first_name;
                    author.LastName = model.last_name;

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

        #region Add Author

        [HttpPost]
        public async Task<IActionResult> Add(AuthorViewModel model)
        {
            try
            {
                if (model != null)
                {
                    var author = new Author()
                    {
                        Id = Guid.NewGuid(),
                        FirstName = model.first_name,
                        LastName = model.last_name,
                    };

                    await dBContext.authors.AddAsync(author);
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
        public IActionResult DeleteAuthor(AuthorViewModel model)
        {
            try
            {
                var author = dBContext.authors.Where(x => x.Id == model.id).FirstOrDefault();
                if (author != null) 
                {
                    dBContext.authors.Remove(author);
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
    }
}
