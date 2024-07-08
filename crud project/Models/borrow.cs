using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud_project.Models
{
    public class borrow
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string borrowing_period { get; set; }



        [ForeignKey("book")]
        public int bookid { get; set; }
        public book Book { get; set; }

        [ForeignKey("student")]
        public int studentid { get; set; }
        public student Student { get; set; }

        /*
                [ForeignKey("student")]
        public int studentid { get; set; }
        public student Student { get; set; }
         * 
       // Foreign key   
       [Display(Name = "book")]
       public virtual int book_id { get; set; }

       [ForeignKey("book_id")]
       public virtual book book { get; set; }


       // Foreign key   
       [Display(Name = "student")]
       public virtual int student_id { get; set; }

       [ForeignKey("student_id")]
       public virtual student Student { get; set; }

       public int student_id { get; set; }
       public virtual student Student { get; set; }

       public int book_id { get; set; }
       public virtual book Book { get; set; }
       */

    }
}
