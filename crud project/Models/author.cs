using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace crud_project.Models
{
    public class author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public string Email { get; set; }

        public string img { get; set; }
       
        public ICollection<bookauthor> Bookauthors { get; set; }
        /*
         *  public ICollection<book> Books { get; set; }
        public ICollection<bookauthor> bookauthors { get; set; }
        
        public ICollection<book> Books { get; set; }
        public ICollection<bookauthor> bookauthors { get; set; }
        */

    }
}
