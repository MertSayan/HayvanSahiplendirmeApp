using Application.Constants;
using Application.Features.MediatR.PetLikes.Commands;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetLikeLikesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PetLikeLikesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreatePetLike(CreatePetLikeCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<PetLike>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePetLike(UpdatePetLikeCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<PetLike>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePetLike(int id)
        {
            await _mediator.Send(new DeletePetLikeCommand(id));
            return Ok(Messages<PetLike>.EntityDeleted);

        }
    }
}
