using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud_project.Models
{
    public class report
    {
        public int Id { get; set; }

        public string rName { get; set; }
        public string rReport { get; set; }

        public double Rate { get; set; }


        [ForeignKey("bookid")]
        public int bookid { get; set; }
        public book Book { get; set; }




    }
}
