using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp_demo.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        public int Price { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
