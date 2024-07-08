 using System.ComponentModel.DataAnnotations.Schema;

namespace crud_project.Models
{
    public class bookauthor
    {
        
        public int Id { get; set; }

        [ForeignKey("book")]
        public int bookid { get; set; }
        public book Book { get; set; }

        [ForeignKey("author")]
        public int authorid { get; set; }
        public author Author { get; set; }

        [ForeignKey("category")]
        public int categoryid { get; set; }
        public category Category { get; set; }



    }
}
