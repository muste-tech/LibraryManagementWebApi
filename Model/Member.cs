namespace LibraryProject.Model
{
   public class Member
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public DateTime MembershipDate { get; set; }
     public ICollection<BorrowRecord> BorrowRecords { get; set; }
}
}