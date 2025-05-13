using Application.Constants;
using Application.Features.MediatR.AdoptionTrackings.Commands;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptionTrackingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdoptionTrackingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateAdoptionTracking(CreateAdoptionTrackingCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<AdoptionTracking>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAdoptionTracking(UpdateAdoptionTrackingCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<AdoptionTracking>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAdoptionTracking(int id)
        {
            await _mediator.Send(new DeleteAdoptionTrackingCommand(id));
            return Ok(Messages<AdoptionTracking>.EntityDeleted);
        }

    }
}
