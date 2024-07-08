using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud_project.Models
{
    public class book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double  publishyear { get; set; }


        [ForeignKey("admin")]
        public int adminid { get; set; }
        public admin Admin { get; set; }





        public ICollection<borrow> Borrows { get; set; }
        public ICollection<bookauthor> Bookauthors { get; set; }

        public ICollection<report> Reports { get; set; }

        /*
        public ICollection<bookauthor> bookauthors { get; set; }
        public ICollection<report> reports { get; set; }
        
                [ForeignKey("author")]
        public int authorid { get; set; }
        public author Author { get; set; }
        [ForeignKey("admin")]
        public int adminid { get; set; }
        public admin admin { get; set; }

        [ForeignKey("category")]
        public int categoryid { get; set; }
        public category category { get; set; }
        
       // Foreign key   
       [Display(Name = "admin")]
       public virtual int admin_id { get; set; }

       [ForeignKey("admin_id")]
       public virtual admin Admin { get; set; }
       // Foreign key   
       [Display(Name = "category")]
       public virtual int category_id { get; set; }

       [ForeignKey("category_id")]
       public virtual category Category { get; set; }

       // Foreign key   
       [Display(Name = "author")]
       public virtual int author_id { get; set; }

       [ForeignKey("author_id")]
       public virtual author Author { get; set; }


       public int category_id { get; set; }
       public virtual category Category { get; set; }
       public int admin_id { get; set; }
       public virtual admin Admin { get; set; }
       public int author_id { get; set; }
       public virtual author Author { get; set; }

       public ICollection<bookauthor> bookauthors { get; set; }
       public ICollection<report> Reports { get; set; }
       public ICollection<borrow> Borrows { get; set; }
       */

    }
}
