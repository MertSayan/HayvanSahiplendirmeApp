using Application.Constants;
using Application.Features.MediatR.Pets.Commands;
using Application.Features.MediatR.Users.Commands;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var token = await _mediator.Send(command);
            return Ok(new { token });
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<User>.EntityAdded);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<User>.EntityUpdated);
        }

        [HttpPut("UpdateAdminUser")]
        public async Task<IActionResult> UpdateAdminUser(UpdateUserByAdminCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<User>.EntityUpdated);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<User>.EntityDeleted);
        }
        
    }
}
