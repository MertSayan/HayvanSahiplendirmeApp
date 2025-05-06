using Application.Constants;
using Application.Features.MediatR.PetComments.Commands;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetCommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PetCommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePetComment(CreatePetCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<PetComment>.EntityAdded); 
        }
    }


}
