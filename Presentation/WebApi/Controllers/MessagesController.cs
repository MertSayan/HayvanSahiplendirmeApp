using Application.Features.MediatR.Messages.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetConversation")]
        public async Task<IActionResult> GetConversation(int userId1, int userId2)
        {
            var result = await _mediator.Send(new GetMessagesBetweenUsersQuery
            {
                UserId1 = userId1,
                UserId2 = userId2
            });

            return Ok(result);
        }
    }
}
