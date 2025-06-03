using Application.Constants;
using Application.Features.MediatR.AdoptionRequests.Commands;
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
        public async Task<IActionResult> GetByIdPet(int petId,int currentUserId)
        {
            var value=await _mediator.Send(new GetByIdPetQuery(petId,currentUserId));
            return Ok(value);
        }
        [HttpGet("ByIdForUpdate")]
        public async Task<IActionResult> GetPetById(int id)
        {
            var value = await _mediator.Send(new GetPetByIdQuery(id));
            return Ok(value);
        }
        
        [HttpGet("GetAllPetByOwnerId")]
        public async Task<IActionResult> GetAllPetByOwnerId(int id)
        {
            var value = await _mediator.Send(new GetAllPetByOwnerIdQuery(id));
            return Ok(value);
        }
        [HttpGet("AllActivePetByOwnerId")]
        public async Task<IActionResult> GetAllActivePetByOwnerId(int id)
        {
            var values = await _mediator.Send(new GetAllActivePetByOwnerIdQuery(id));
            return Ok(values);
        }
        [HttpGet("AllAdoptedPetByOwnerId")]
        public async Task<IActionResult> GetAllAdoptedPetByOwnerId(int ownerId)
        {
            var values = await _mediator.Send(new GetAllAdoptedPetByOwnerIdQuery(ownerId));
            return Ok(values);
        }
        [HttpGet("Filter")]
        public async Task<IActionResult> FilterPets([FromQuery] GetAllFilterPetQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("Top3LikePet")]
        public async Task<IActionResult> GetFeaturedPets(int sayi)
        {
            var result = await _mediator.Send(new GetFeaturedPetQuery(sayi));
            return Ok(result);
        }
        [HttpGet("LastPets")]
        public async Task<IActionResult> GetLastPets(int count)
        {
            var result = await _mediator.Send(new GetLastsPetQuery(count));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePet([FromForm] CreatePetCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Pet>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePet([FromForm] UpdatePetCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Pet>.EntityUpdated);
        }
        [HttpPut("Accept")]
        public async Task<IActionResult> UpdatePetAccept([FromBody] UpdatePetAcceptCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut("Reject")]
        public async Task<IActionResult> UpdatePetReject([FromBody] UpdatePetRejectCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePet(int id)
        {
            await _mediator.Send(new DeletePetCommand(id));
            return Ok(Messages<Pet>.EntityDeleted);

        }
    }
}
