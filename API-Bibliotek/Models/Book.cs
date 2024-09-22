using System.ComponentModel.DataAnnotations;

namespace API_Bibliotek.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(75)]
        public string Title { get; set; }
        [MaxLength(75)]
        public string Author { get; set; }
        [MaxLength(75)]
        public int Year { get; set; }
        [MaxLength(75)]
        public string Genre { get; set; }
        [MaxLength(125)]
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
    }
}
