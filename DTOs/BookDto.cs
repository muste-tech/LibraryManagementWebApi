namespace LibraryProject.DTOs
{
    public class CreateBookRequest
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public int TotalCopies { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }

    public class UpdateBookRequest
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int TotalCopies { get; set; }
    }

    public class BookResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int AvailableCopies { get; set; }
    }
}