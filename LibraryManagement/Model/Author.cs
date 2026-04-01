namespace LibraryProject.Model
{
    public class Author
    {
        public int Id {get; set;}
        public string FullName {get; set;}
        public string Biography {get; set;}
        public ICollection<Book>Books {get; set;}
    }
}