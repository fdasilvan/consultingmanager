using ConsultingManager.Domain.Repository;
using ConsultingManager.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Auth.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserDto userDto)
        {
            var user = await _userRepository.Add(userDto);

            if (user == null)
                return BadRequest(new { message = "Erro ao cadastrar o usuário: " + userDto.Name });

            return Ok(user);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserDto userDto)
        {
            var user = await _userRepository.Authenticate(userDto.Email, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet("{userId}/meetings")]
        public async Task<IActionResult> GetUserMeetings(Guid userId)
        {
            try
            {
                return Ok(await _userRepository.GetUserMeetings(userId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar encontros do usuário: " + userId);
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            try
            {
                return Ok(await _userRepository.GetUser(userId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar encontros do usuário: " + userId);
            }
        }

        [HttpGet("user-types")]
        public async Task<IActionResult> GetUserTypes()
        {
            try
            {
                return Ok(await _userRepository.GetUserTypes());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        [HttpPost("consultant")]
        public async Task<IActionResult> SaveConsultant(UserDto userDto)
        {
            return Ok(await _userRepository.SaveConsultant(userDto));
        }
    }
}
