using Application.Constants;
using Application.Features.MediatR.PetComments.Commands;
using Application.Features.MediatR.PetComments.Queries;
using Application.Features.MediatR.Pets.Commands;
using Application.Features.MediatR.Pets.Queries;
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

        [HttpGet]
        public async Task<IActionResult> GetAllPetCommentByPetId(int id)
        {
            var values = await _mediator.Send(new GetAllPetCommentByPetIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePetComment(CreatePetCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<PetComment>.EntityAdded); 
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePetComment(UpdatePetCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Pet>.EntityUpdated);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePetCommmnet(int petCommentId)
        {
            await _mediator.Send(new DeletePetCommand(petCommentId));
            return Ok(Messages<Pet>.EntityDeleted);

        }
    }


}
