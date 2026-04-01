namespace LibraryProject.DTOs
{
    public class BorrowRequest
    {
        public int BookId { get; set; }
        public int MemberId { get; set; }
    }

    public class BorrowResponse
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsReturned { get; set; }
    }
}