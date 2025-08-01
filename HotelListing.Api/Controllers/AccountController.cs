using Grpc.Core;
using HotelListing.Api.Contracts;
using HotelListing.API.Contracts;
using HotelListing.API.Models.Users;
using HotelListing.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAuthManager _authManager;

        public AccountController(IAuthManager authManager, ILogger<AccountController> logger )
        {
            this._authManager = authManager;
            this._logger = logger;
        }

        // POST: api/Account/register
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register([FromBody] ApiUserDto apiUserDto)
        {
            _logger.LogInformation($"Registering a new user with email: {apiUserDto.Email}");
            try
            {
                var errors = await _authManager.Register(apiUserDto, "User");

                if (errors.Any())
                {
                    foreach (var error in errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                                _logger.LogError(ex, $"An error occurred in the {nameof(Register)} with the user {apiUserDto.Email}");
                return Problem($"Something Went Wrong In The {nameof(Register)}", statusCode: 500);
            }
        }

        // POST: api/Account/register
        [HttpPost]
        [Route("registerAdmin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> RegisterAdmin([FromBody] ApiUserDto apiUserDto)
        {

            _logger.LogInformation($"user registerring Admin with email: {apiUserDto.Email}");
            try
            {
                var errors = await _authManager.Register(apiUserDto, "Administrator");

                if (errors.Any())
                {
                    foreach (var error in errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred in the {nameof(RegisterAdmin)} with the user {apiUserDto.Email}");
                return Problem($"Something Went Wrong In The {nameof(RegisterAdmin)}", statusCode: 500);
            }
        }

        // POST: api/Account/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {


            _logger.LogInformation($"user registerring Admin with email: {loginDto.Email}");
            try
            {
                var authResponse = await _authManager.Login(loginDto);

                if (authResponse == null)
                {
                    return Unauthorized();
                }

                return Ok(authResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred in the {nameof(Login)} with the user {loginDto.Email}");
                return Problem($"Something Went Wrong In The {nameof(Login)}", statusCode: 500);
            }
        }
        

        // POST: api/Account/refreshtoken
        [HttpPost]
        [Route("refreshtoken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDto request)
        {
            var authResponse = await _authManager.VerifyRefreshToken(request);

            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }
    }
}