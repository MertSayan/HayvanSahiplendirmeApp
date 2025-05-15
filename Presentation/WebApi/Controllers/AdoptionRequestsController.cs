using Application.Constants;
using Application.Features.MediatR.AdoptionRequests.Commands;
using Application.Features.MediatR.AdoptionRequests.Queries;
using Application.Features.MediatR.Pets.Queries;
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

        [HttpGet]
        public async Task<IActionResult> GetAllAdoptionRequest()
        {
            var values = await _mediator.Send(new GetAllAdoptionRequestQuery());
            return Ok(values);
        }
        [HttpGet("GetAllAdoptionRequestByPetId")]
        public async Task<IActionResult> GetAllAdoptionRequestByPetId(int petId)
        {
            var values = await _mediator.Send(new GetAllAdoptionRequestByPetIdQuery(petId));
            return Ok(values);
        }
        [HttpGet("GetAllIncomingAdoptionByOwnerId")]
        public async Task<IActionResult> GetAllIncomingAdoptionByOwnerId(int ownerId)
        {
            var values = await _mediator.Send(new GetAllIncomingAdoptionByOwnerIdQuery(ownerId));
            return Ok(values);
        }
        [HttpGet("GetAllAdoptiobRequestBySenderId")]
        public async Task<IActionResult> GetAllAdoptionRequestBySenderId(int senderId)
        {
            var values = await _mediator.Send(new GetAllAdoptionRequestBySenderIdQuery(senderId));
            return Ok(values);
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetByIdAdoptionRequest(int id)
        {
            var value = await _mediator.Send(new GetByIdAdoptionRequestQuery(id));
            return Ok(value);
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
