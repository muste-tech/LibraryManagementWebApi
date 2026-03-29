using Microsoft.EntityFrameworkCore;
using LibraryProject.Data;
using LibraryProject.Model;
using LibraryProject.Repositories.Interfaces;

namespace LibraryProject.Repositories
{ 
    public class MemberRepoitory:IMemberRepoitory
    {
        private readonly LibraryDbContext _context;

        public MemberRepoitory (LibraryDbContext context)
        {
            _context=context;
        }
       
         public async Task <IEnumerable<Member>> GetAllMemberAsync()
        {
           return await _context.Members.ToListAsync();
        }
        public async Task <Member> GetMemberByIdAsync (int id)
        {
            return await _context.Members.FindAsync(id);
        }
        public async Task RegisterMemberAsync (Member member)
        {
            await _context.Members.RegisterAsync(member);
        }
        
        public void UpdateMember (Member member)
        {
            _context.Members.Update(member);
        }
        public void DeleteMember (Member member)
        {
            _context.Members.Remove(member);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}