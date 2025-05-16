using Application.Constants;
using Application.Features.MediatR.PetFavorites.Commands;
using Application.Features.MediatR.PetFavorites.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetFavoritiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PetFavoritiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllMyFavoritePet")]
        public async Task<IActionResult> GetAllFavoritePet(int userId)
        {
            var values = await _mediator.Send(new GetAllFavoritePetQuery(userId));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePetFavorite(CreatePetFavoriteCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<PetFavorite>.EntityAdded);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePetFavorite(int id)
        {
            await _mediator.Send(new DeletePetFavoriteCommand(id));
            return Ok(Messages<PetFavorite>.EntityDeleted);
        }
    }
}
