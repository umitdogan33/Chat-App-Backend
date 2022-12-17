using Application.Features.Users.Commands.AddFriendCommand;
using Application.Features.Users.Commands.ChangeUsername;
using Application.Features.Users.Queries.GetAllByOnline;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetListUser;
using Application.Features.Users.Queries.PendingFriendRequests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] GetUserListQuery query)
        {
            var data = await _mediator.Send(query);
            return Ok(data);
        }
        
        [HttpGet("getuserbyid")]
        public async Task<IActionResult> GetUserById([FromQuery] GetUserByIdQuery query)
        {
            var data = await _mediator.Send(query);
            return Ok(data);
        }

        [HttpGet("getbystatus")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUserByOnlineQuery query)
        {
            var data = await _mediator.Send(query);
            return Ok(data);
        }

        [HttpGet("PendingFriendRequests")]
        public async Task<IActionResult> PendingFriendRequests([FromQuery] PendingFriendRequestsQuery query)
        {
            var data = await _mediator.Send(query);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SendFriendRequest(AddFriendCommand command) {
            var data =await _mediator.Send(command);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ChangeUsername(ChangeFeelTextCommand command) {
            var data =await _mediator.Send(command);
            return Ok(data);
        }

    }
}
