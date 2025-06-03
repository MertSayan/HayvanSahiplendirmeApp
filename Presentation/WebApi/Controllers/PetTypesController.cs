using Application.Features.MediatR.Pets.Queries;
using Application.Features.MediatR.PetTypes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetTypesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PetTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPetTypes()
        {
            var values = await _mediator.Send(new GetAllPetTypeQuery());
            return Ok(values);
        }
        [HttpGet("GetPetTypeCount")]
        public async Task<IActionResult> GetPetTypeCount()
        {
            var values = await _mediator.Send(new GetPetTypeDistributionQuery());
            return Ok(values);
        }

    }
}
