using Application.Constants;
using Application.Features.MediatR.Pets.Commands;
using Application.Features.MediatR.Pets.Queries;
using Application.Features.MediatR.Users.Commands;
using Application.Features.MediatR.Users.Queries;
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

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var values = await _mediator.Send(new GetAllUserQuery());
            return Ok(values);
        }

        [HttpGet("GetByIdUser")]
        public async Task<IActionResult> GetByIdUser(int id)
        {
            var value = await _mediator.Send(new GetByIdUserQuery(id));
            return Ok(value);
        }

        [HttpGet("GetByIdUserDetailsForAdmin")]
        public async Task<IActionResult> GetByIdUserDetailsForAdmin(int id)
        {
            var value = await _mediator.Send(new GetByIdUserDetailsForAdminQuery(id));
            return Ok(value);
        }
        
        [HttpGet("GetByIdUserProfileStats")]
        public async Task<IActionResult> GetByIdUserProfileStats(int id)
        {
            var value = await _mediator.Send(new GetByIdUserProfileStatsQuery(id));
            return Ok(value);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var token = await _mediator.Send(command);
            return Ok(new { token });
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromForm]CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<User>.EntityAdded);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromForm] UpdateUserCommand command)
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
