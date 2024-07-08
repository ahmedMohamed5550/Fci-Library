using crud_project.Data;
using crud_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace crud_project.Controllers
{
    public class adminController : Controller
    {
        libraryDbContext db;
        IWebHostEnvironment env;

        public adminController(libraryDbContext db,IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }   
        public IActionResult Index()
        {
            var email = HttpContext.Session.GetString("email");
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("index", "login");
            }
            return View();                  
        }
        public IActionResult addbook()
        {
            
                ViewData["adminid"] = new SelectList(db.Admins, "Id", "email");
                return View();
            

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addbook([Bind("Name,publishyear,adminid")] book book)
        {
            try
            {
                db.Add(book);
                await db.SaveChangesAsync();
                return RedirectToAction("addbookdetails");
            }

            catch (Exception ex) {
                return View();
            }
        }



        public IActionResult addcategory()
        {
            return View();
        }
        // add category
        [HttpPost]
        public IActionResult addcategory(category category)
        {
            try
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("listcategory");
            }
            catch (Exception ex)
            {
                return View();
            }
            

        }

        // edit category

        public async Task<IActionResult> editcategory(int? id)
        {

            var category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> editcategory(int id, [Bind("Id,Name")] category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }
            
                    db.Update(category);
                    await db.SaveChangesAsync();               
                return RedirectToAction("listcategory");

        }


        // delete category
        public IActionResult deletecategory(int id)
        {
            category cat = db.Categories.Where(c => c.Id == id).FirstOrDefault();
            db.Categories.Remove(cat);
            db.SaveChanges();
            return RedirectToAction("listcategory");
        }
        public IActionResult addauthor()
        {
            return View();
        }

        //add author

        [HttpPost]
        public async Task<IActionResult> addauthor([Bind("Name,age,Email")] author author, IFormFile img)
        {
            string path = Path.Combine(env.WebRootPath, "Img");  // add image to folder img
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (img != null)
            {
                path = Path.Combine(path, img.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await img.CopyToAsync(stream);
                    author.img = img.FileName;
                }
            }
            else
            {
                author.img = "1.jpg";
            }

            try
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("listauthor");
            }
            catch (Exception ex)
            {
                ViewBag.Ex = ex.Message;
            }
            return View();
        }
        // show author profile
        public IActionResult showauthorprofile(int id)
        {
            author au = db.Authors.Where(c => c.Id == id).FirstOrDefault();
            return View(au);
        }

        // delete author
        public IActionResult deleteauthor(int id)
        {
            author au = db.Authors.Where(c => c.Id == id).FirstOrDefault();
            db.Authors.Remove(au);
            db.SaveChanges();
            return RedirectToAction("listauthor");
        }
        public IActionResult addbookdetails()
        {
            ViewData["authorid"] = new SelectList(db.Authors, "Id", "Name");
            ViewData["bookid"] = new SelectList(db.Books, "Id", "Name");
            ViewData["categoryid"] = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addbookdetails([Bind("Id,bookid,authorid,categoryid")] bookauthor bookauthor)
        {
            
            
                db.Add(bookauthor);
                await db.SaveChangesAsync();
                return RedirectToAction("index","book");
            
            //ViewData["authorid"] = new SelectList(db.Authors, "Id", "Id", bookauthor.authorid);
            //ViewData["bookid"] = new SelectList(db.Books, "Id", "Id", bookauthor.bookid);
            //ViewData["categoryid"] = new SelectList(db.Categories, "Id", "Id", bookauthor.categoryid);
            return View(bookauthor);
        }

        public IActionResult addstudent()
        {
            return View();
        }

        // add student
        [HttpPost]
        public IActionResult addstudent(student student)
        {

            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("liststudent");
        }



        // list category
        public IActionResult listcategory()
        {
            List<category> categories=db.Categories.ToList();
            return View(categories);
        }

        // list student
        public IActionResult liststudent()
        {
            List<student> students = db.Students.ToList();
            return View(students);
        }

        // delete student
        public IActionResult deletestudent(int id)
        {
            student st = db.Students.Where(c => c.Id == id).FirstOrDefault();
            db.Students.Remove(st);
            db.SaveChanges();
            return RedirectToAction("liststudent");
        }
        public IActionResult listauthor()
        {
            List<author> authors = db.Authors.ToList();
            return View(authors);
        }
        public IActionResult borrowinglist()
        {
            return View();
        }
    }
}
