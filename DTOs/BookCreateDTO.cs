namespace LibreriaApi.DTOs
{
    public class BookCreateDTO
    {
        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public int? Stock { get; set; }
    }
}