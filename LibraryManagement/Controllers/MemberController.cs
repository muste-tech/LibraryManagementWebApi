using LibraryProject.DTOs;
using LibraryProject.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            return Ok(await _memberService.GetAllMembersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberById(int id)
        {
            var member = await _memberService.GetMemberByIdAsync(id);
            if (member == null) return NotFound();
            return Ok(member);
        }

        [HttpPost]
        public async Task<IActionResult> AddMember(CreateMemberRequest request)
        {
            var result = await _memberService.RegisterMemberAsync(request);
            return CreatedAtAction(nameof(GetMemberById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, UpdateMemberRequest request)
        {
            var result = await _memberService.UpdateMemberAsync(id, request);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var result = await _memberService.DeleteMemberAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}