using crud_project.Data;
using crud_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_project.Controllers
{
    public class loginController : Controller
    {
        libraryDbContext db;
        public loginController (libraryDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        // add admin
        [HttpPost]
        public IActionResult Index(admin admin)
        {
            var user = db.Admins.FirstOrDefault(u => u.email == admin.email && u.Password == admin.Password);
                if (user != null)
                {
                HttpContext.Session.SetString("email", admin.email);
                HttpContext.Session.SetString("password", admin.Password);
                return RedirectToAction("index", "admin");
                }
          
                return View();
           
                  
        }

        public IActionResult logout()
        {
            
            if (HttpContext.Session.GetString("email") != null)
            {
                HttpContext.Session.Remove("email");
                HttpContext.Session.Remove("password");
                return RedirectToAction("index", "home");
            }
            return RedirectToAction("index", "login");

        }
    }
}
