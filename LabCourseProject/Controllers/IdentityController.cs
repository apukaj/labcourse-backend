using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LabCourseProject.Contracts.Requests;
using LabCourseProject.Contracts.Responses;
using LabCourseProject.Extensions;
using LabCourseProject.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LabCourseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService, UserManager<IdentityUser> userManager)
        {
            _identityService = identityService;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new RegisterFailResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }
            var registerResponse = await _identityService.RegisterAsync(request.Email , request.UserName, request.Password);

            if (!registerResponse.Success)
            {
                return BadRequest(new RegisterFailResponse
                {
                    Errors = registerResponse.Errors
                });
            }

            return Ok(new RegisterSuccessResponse
            {
                Token = registerResponse.Token
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var registerResponse = await _identityService.LoginAsync(request.Email, request.Password);

            if (!registerResponse.Success)
            {
                return BadRequest(new RegisterFailResponse
                {
                    Errors = registerResponse.Errors
                });
            }

            return Ok(new RegisterSuccessResponse
            {
                Token = registerResponse.Token
            });
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetUserData()
        {
            // to get current user ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // to get current user info
            var user = await _userManager.FindByIdAsync(userId);
            var a = HttpContext.GetUserId();

            return Ok(User);
        }
    }
}
