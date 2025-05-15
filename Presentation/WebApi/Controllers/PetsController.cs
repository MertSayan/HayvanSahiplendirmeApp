using Application.Constants;
using Application.Features.MediatR.Pets.Commands;
using Application.Features.MediatR.Pets.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPet()
        {
            var values=await _mediator.Send(new GetAllPetQuery());
            return Ok(values);
        }
        [HttpGet("ById")]
        public async Task<IActionResult> GetByIdPet(int id)
        {
            var value=await _mediator.Send(new GetByIdPetQuery(id));
            return Ok(value);
        }
        [HttpGet("GetAllPetByOwnerId")]
        public async Task<IActionResult> GetAllPetByOwnerId(int id)
        {
            var value = await _mediator.Send(new GetAllPetByOwnerIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePet(CreatePetCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Pet>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePet(UpdatePetCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Pet>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePet(int id)
        {
            await _mediator.Send(new DeletePetCommand(id));
            return Ok(Messages<Pet>.EntityDeleted);

        }
    }
}
