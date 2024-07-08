using crud_project.Data;
using crud_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace crud_project.Controllers
{
    public class reportController : Controller
    {
        libraryDbContext db;
        IWebHostEnvironment env;

        public reportController(libraryDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult add()
        {
            ViewData["bookid"] = new SelectList(db.Books, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> add([Bind("Id,rName,rReport,Rate,bookid")] report report)
        {
            if (ModelState.IsValid)
            {
                db.Add(report);
                await db.SaveChangesAsync();
                return View();
            }
           return View("list");
        }
        public IActionResult list()
        {
            return View();
        }
    }
}
