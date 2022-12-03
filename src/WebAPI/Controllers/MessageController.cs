using Application.Features.Messages.Queries.GetAllMessageByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController:ControllerBase
{
    private readonly IMediator _mediator;

    public MessageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("getmessagebyuserid")]
    public async Task<IActionResult> GetMessageByUserId([FromQuery]string userId,[FromQuery]string userId2)
    {
        GetAllMessageByUserIdQuery entity = new()
        {
            UserId = userId,
            UserId2 = userId2
        };
        var data = await _mediator.Send(entity);
        return Ok(data);
    }

}