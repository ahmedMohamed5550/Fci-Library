using System.ComponentModel.DataAnnotations;

namespace crud_project.Models
{
    public class admin
    {
        public int Id { get; set; }
        
        public string email { get; set; }
        public string  Password { get; set; }
       
        public ICollection<book> Books { get; set; }

       // public ICollection<student> Students { get; set; }

        /*
       public ICollection<student> students { get; set; }
       public ICollection<book> Books { get; set; }
       */

    }
}
