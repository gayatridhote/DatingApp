using System.Security.Claims;
using api.DTOs;
using api.entities;
using api.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [Authorize] 
    public class UsersController : BaseApiController
    {      
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
           
        }

                       
        [HttpGet]
       public async Task<ActionResult<IEnumerable<MembersDto>>>GetUsers()
        {
            var users = await _userRepository.GetMembersAsync();
            return Ok(users); 
        }


       
        [HttpGet("{username}")]
        public async Task<ActionResult<MembersDto>> GetUser(string username)   
        {
            return await _userRepository.GetMemberAsync(username);
            
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDTO memberUpdateDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userRepository.GetUserByUserNameAsync(username);

            if(user == null) return NotFound(); 

            _mapper.Map(memberUpdateDto, user);

            if(await _userRepository.SaveAllAsync()) return NoContent();
            
            return BadRequest("Failed to update user");
        }
    }
}