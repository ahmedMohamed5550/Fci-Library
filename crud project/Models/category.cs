using System.ComponentModel.DataAnnotations;

namespace crud_project.Models
{
    public class category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<bookauthor> bookauthors { get; set; }
        
    }
}
