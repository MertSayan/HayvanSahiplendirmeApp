using Application.Constants;
using Application.Features.MediatR.AdoptionRequests.Commands;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptionRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdoptionRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdoptionRequest(CreateAdoptionRequestCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<AdoptionRequest>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAdoptionRequest(UpdateAdoptionRequestCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<AdoptionRequest>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAdoptionRequest(int id)
        {
            await _mediator.Send(new DeleteAdoptionRequestCommand(id));
            return Ok(Messages<AdoptionRequest>.EntityDeleted);
        }
    }
}
