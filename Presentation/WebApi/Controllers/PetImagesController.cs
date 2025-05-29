using Application.Constants;
using Application.Features.MediatR.PetImages.Commands;
using Application.Features.MediatR.PetImages.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetImagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PetImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPetImage(int id)
        {
            var values = await _mediator.Send(new GetPetImagesByPetIdQuery(id));
            return Ok(values);
        }

        [HttpPost]   
        public async Task<IActionResult> CreatePetImages([FromForm]CreatePetImagesCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<PetImage>.EntitiesAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePetImage([FromForm] UpdatePetImageCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<PetImage>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePetImage(DeletePetImageCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<PetImage>.EntityDeleted);
        }
    }
}
