using Application.Facades.PetFacades;
using Application.Facades.UserFacades;
using Application.Features.MediatR.Pets.Commands;
using Application.Features.MediatR.Users.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Users.Handlers.Write
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly UserFacade _userFacade;

        public UpdateUserCommandHandler(UserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _userFacade.UpdateUserAsync(request);
            return Unit.Value;
        }
    }
}
