namespace LibraryProject.Model
{
    public class Author
    {
        public int Id {get; set;}
        public string Fullname {get; set;}
        public string Biography {get; set;}
        public ICollection<Book>Books {get; set;}
    }
}