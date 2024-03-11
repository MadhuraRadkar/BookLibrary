using BookLibrary.Models;
using BookLibrary.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryService service;
        public LibraryController(ILibraryService service)
        {
            this.service = service;
        }

        // GET: LibraryController
        public ActionResult Index()
        {
            var model = service.GetBooks();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string searchText)
        {
            var books = service.GetBookByTitle(searchText);
            return View("Index", books);
        }

        // GET: LibraryController/Details/5
        public ActionResult Details(int id)
        {
            var book = service.GetBookByID(id); 
            return View(book);
        }

        // GET: LibraryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibraryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Library library)
        {
            try
            {
                int result = service.AddBook(library);
                if(result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(library);
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

      

        // GET: LibraryController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = service.GetBookByID(id);
            return View(book);
        }

        // POST: LibraryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = service.DeleteBook(id);
                if(result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex) 
            {
                return View();
            }
        }
    }
}
