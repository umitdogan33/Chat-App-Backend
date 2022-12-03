using Application.Features.Auth.Commands.CreateTokenWithRefreshToken;
using Application.Features.Auth.Commands.CreateUserCommand;
using Application.Features.Auth.Commands.GoogleLogin;
using Application.Features.Auth.Commands.LoginUserCommand;
using Application.Features.Users.Queries.GetAllByOnline;
using Application.Features.Users.Queries.GetListUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUserCommand command) {
            var data = await _mediator.Send(command);
            return Ok(data);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var data = await _mediator.Send(command);
            return Ok(data);
        }

        [HttpPost("LoginGoogle")]
        public async Task<IActionResult> LoginGoogle(GoogleLoginCommand command)
        {
            var data = await _mediator.Send(command);
            return Ok(data);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(CreateTokenWithRefreshTokenCommand command)
        {
            var data = await _mediator.Send(command);
            return Ok(data);
        }

        

    }
}
