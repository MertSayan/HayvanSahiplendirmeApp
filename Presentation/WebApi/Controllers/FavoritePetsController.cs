using Application.Features.MediatR.PetFavorites.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritePetsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FavoritePetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllMyFavoritePet")]
        public async Task<IActionResult> GetAllFavoritePet(int userId)
        {
            var values = await _mediator.Send(new GetAllFavoritePetQuery(userId));
            return Ok(values);
        }
    }
}
