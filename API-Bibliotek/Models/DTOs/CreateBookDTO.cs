namespace API_Bibliotek.Models.DTOs
{
    public class CreateBookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
    }
}
