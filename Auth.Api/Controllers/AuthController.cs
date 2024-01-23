using AuthApi.Data;
using AuthApi.Infrastructure;
using AuthApi.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private ResponseDto _response;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
            _response = new();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var errorMessage = await _authService.Register(registerDto);
            if (string.IsNullOrEmpty(errorMessage) == false)
            {
                _response.IsSuccessful = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            return Ok(_response);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var loginResponseDto = await _authService.Login(loginRequestDto);
            if (loginResponseDto.User is null)
            {
                _response.IsSuccessful = false;
                _response.Message = "Username or Password are incorrect!";
                return BadRequest(_response);
            }

            _response.Result = loginResponseDto;
            return Ok(_response);
        }

        [HttpPost("assigntorole")]
        public async Task<IActionResult> AssignToRole([FromBody] RegisterDto registerDto)
        {
            var succeeded = await _authService.AssignToRole(registerDto.UserName, registerDto.RoleName);
            if (!succeeded)
            {
                _response.IsSuccessful = false;
                _response.Message = "AssignToRole Error";
                return BadRequest(_response);
            }

            return Ok(_response);
        }
    }
}
