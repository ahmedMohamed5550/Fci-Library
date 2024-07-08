using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud_project.Models
{
    public class student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }

       public ICollection<borrow> Borrows { get; set; }

        /*
                [ForeignKey("admin")]
        public int adminid { get; set; }
        public admin Admin { get; set; }
        // Foreign key   
        [Display(Name = "admin")]
        public virtual int admin_id { get; set; }

        [ForeignKey("admin_id")]
        public virtual admin Admin { get; set; }
        
        public int admin_id { get; set; }
        public virtual admin Admin { get; set; }
        public ICollection<borrow> Borrows { get; set; }
        */


    }
}
