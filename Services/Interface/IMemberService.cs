using LibraryProject.DTOs;
using System.Runtime.InteropServices;

namespace LibraryProject.Services.Interface
{
    public interface IMemberService
    {
        Task <IEnumerable<MemberResponse>>GetAllMembersAsync();
        Task <MemberResponse?> GetMemberByIdAsync(int id);
        Task <MemberResponse> RegisterMemberAsync(CreateMemberRequest request);
        Task <bool> UpdateMemberAsync(int Id, UpdateMemberRequest request);
        Task<bool> DeleteMemberAsync(int id);
    }
}