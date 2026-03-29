using LibraryProject.DTOs;
using LibraryProject.Model;
using LibraryProject.Repositories.Interfaces;
using LibraryProject.Services.Interface;

namespace LibraryProject.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repo;

        public MemberService(IMemberRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<MemberResponse>> GetAllMembersAsync()
        {
            var members = await _repo.GetAllMembersAsync();

            return members.Select(m => new MemberResponse
            {
                Id = m.Id,
                FullName = m.FullName,
                Email = m.Email,
                PhoneNumber = m.PhoneNumber,
                MembershipDate = m.MembershipDate
            });
        }

        public async Task<MemberResponse?> GetMemberByIdAsync(int id)
        {
            var m = await _repo.GetMemberByIdAsync(id);
            if (m == null) return null;

            return new MemberResponse
            {
                Id = m.Id,
                FullName = m.FullName,
                Email = m.Email,
                PhoneNumber = m.PhoneNumber,
                MembershipDate = m.MembershipDate
            };
        }

        public async Task<MemberResponse> AddMemberAsync(CreateMemberRequest request)
        {
            var member = new Member
            {
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                MembershipDate = DateTime.Now
            };

            await _repo.AddMemberAsync(member);
            await _repo.SaveChangesAsync();

            return new MemberResponse
            {
                Id = member.Id,
                FullName = member.FullName,
                Email = member.Email,
                PhoneNumber = member.PhoneNumber,
                MembershipDate = member.MembershipDate
            };
        }

        public async Task<bool> UpdateMemberAsync(int id, UpdateMemberRequest request)
        {
            var member = await _repo.GetMemberByIdAsync(id);
            if (member == null) return false;

            member.FullName = request.FullName;
            member.Email = request.Email;
            member.PhoneNumber = request.PhoneNumber;

            _repo.UpdateMember(member);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteMemberAsync(int id)
        {
            var member = await _repo.GetMemberByIdAsync(id);
            if (member == null) return false;

            _repo.DeleteMember(member);
            await _repo.SaveChangesAsync();

            return true;
        }
    }
}