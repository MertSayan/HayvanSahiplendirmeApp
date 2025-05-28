using Application.Constants;
using Application.Features.MediatR.PetLikes.Commands;
using Application.Features.MediatR.PetLikes.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetLikesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PetLikesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllPetLikeByPetId")]
        public async Task<IActionResult> GetAllPetLikeByPetId(int petId)
        {
            var results=await _mediator.Send(new GetAllPetLikeByPetIdQuery(petId));
            return Ok(results);
        }
        [HttpGet("GetAllPetLikeByUserId")]
        public async Task<IActionResult> GetAllPetLikeByUserId(int userId)
        {
            var results=await _mediator.Send(new GetAllPetLikeByUserIdQuery(userId));
            return Ok(results);
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
        public async Task<IActionResult> DeletePetLike(int userId,int petId)
        {
            await _mediator.Send(new DeletePetLikeCommand(userId,petId));
            return Ok(Messages<PetLike>.EntityDeleted);

        }
    }
}
