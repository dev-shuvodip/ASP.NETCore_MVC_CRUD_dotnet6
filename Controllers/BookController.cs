using Microsoft.AspNetCore.Mvc;
using WebApp_demo.Data;
using WebApp_demo.Models;

namespace WebApp_demo.Controllers
{
    public class BookController : Controller
    {

        private readonly ApplicationDBContext _db;
        public BookController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> objBookList = _db.Books;
            return View(objBookList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book obj)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bookFromDB = _db.Books.Find(id);

            if (bookFromDB == null)
            {
                return NotFound();
            }

            return View(bookFromDB);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book obj)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bookFromDB = _db.Books.Find(id);

            if (bookFromDB == null)
            {
                return NotFound();
            }

            return View(bookFromDB);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBook(int? id)
        {
            var obj = _db.Books.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Books.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
