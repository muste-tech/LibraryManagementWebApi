namespace LibraryProject.DTOs
{
    public class CreateAuthorRequest
    {
        public string FullName { get; set; }
        public string Biography { get; set; }
    }

    public class UpdateAuthorRequest
    {
        public string FullName { get; set; }
        public string Biography { get; set; }
    }

    public class AuthorResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Biography { get; set; }
    }
}