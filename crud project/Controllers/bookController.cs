using crud_project.Data;
using crud_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace crud_project.Controllers
{
    public class bookController : Controller
    {
        libraryDbContext db;
        IWebHostEnvironment env;

        public bookController(libraryDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public async Task<IActionResult> index()
        {
            var libraryDbContext = db.Bookauthors.Include(b => b.Author).Include(b => b.Book).Include(b => b.Category);
            return View(await libraryDbContext.ToListAsync());

        }

        // show book

        public async Task<IActionResult> showbook(int? id)
        {
            if (id == null || db.Bookauthors == null)
            {
                return NotFound();
            }

            var bookauthor = await db.Bookauthors
                .Include(b => b.Author)
                .Include(b => b.Book)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookauthor == null)
            {
                return NotFound();
            }

            return View(bookauthor);
        }

        // search book
        public IActionResult search(string value)
        {
            var book = db.Books.Where(x => x.Name.Contains(value)).ToList();
            return View("search",book);
        }

        //delete book
        public IActionResult deletebook(int id)
        {
            var email = HttpContext.Session.GetString("email");
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("index", "login");
            }

            bookauthor bk = db.Bookauthors.Where(c => c.Id == id).FirstOrDefault();
            db.Bookauthors.Remove(bk);
            db.SaveChanges();
            return RedirectToAction("index", "book");
        }



        // borrow book
        public async Task<IActionResult> borrow(int? id)
        {
            var borrow = await db.Borrows.FindAsync(id);

            ViewData["bookid"] = new SelectList(db.Books, "Id", "Name");
            ViewData["studentid"] = new SelectList(db.Students, "Id", "email");
            return View(borrow);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> borrow([Bind("Name,borrowing_period,bookid,studentid")] borrow borrow)
        {

            

            db.Add(borrow);
            await db.SaveChangesAsync();
            return RedirectToAction("index");


        }

        // list borrow

        public async Task<IActionResult> borrowinglist()
        {
            var email = HttpContext.Session.GetString("email");
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("index", "login");
            }
            var libraryDbContext = db.Borrows.Include(b => b.Book).Include(b => b.Student);
            return View( await libraryDbContext.ToListAsync());
            
        }

        // delete borrow
        public async Task<IActionResult> Deleteborrowinglist(int id)
        {

            borrow br = db.Borrows.Where(c => c.Id == id).FirstOrDefault();
            db.Borrows.Remove(br);
            db.SaveChanges();
            return RedirectToAction("borrowinglist", "book");
        }




        // edit book
        public async Task<IActionResult> edit(int id)
        {
            var email = HttpContext.Session.GetString("email");
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("index", "login");
            }
            var bookauthor = await db.Bookauthors.FindAsync(id);
            if (bookauthor == null)
            {
                return NotFound();
            }
            ViewData["authorid"] = new SelectList(db.Authors, "Id", "Name", bookauthor.authorid);
            ViewData["bookid"] = new SelectList(db.Books, "Id", "Name", bookauthor.bookid);
            ViewData["categoryid"] = new SelectList(db.Categories, "Id", "Name", bookauthor.categoryid);
            return View(bookauthor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> edit(int id, [Bind("Id,bookid,authorid,categoryid")] bookauthor bookauthor)
        {
            if (id != bookauthor.Id)
            {
                return NotFound();
            }
                
             db.Update(bookauthor);
              await db.SaveChangesAsync();              
            return View(bookauthor);
        }
    }
}
