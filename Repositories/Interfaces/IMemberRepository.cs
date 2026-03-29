using LibraryProject.Model;

namespace LibraryProject.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        Task <IEnumerable<Member>> GetAllMemberAsync();
        Task <Member> GetMemberByIdAsync (int id);
        Task RegisterMemberAsync (Member member);
        void DeleteMember (Member member);
        void UpdateMember (Member member) ;
        Task SaveChangesAsync();
    }
}