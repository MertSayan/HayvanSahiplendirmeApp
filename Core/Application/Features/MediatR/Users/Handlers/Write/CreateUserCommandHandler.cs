using Application.Enums;
using Application.Factories;
using Application.Features.MediatR.Users.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.Users.Handlers.Write
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IRepository<User> _repository;
        private readonly IUserFactory _userFactory;

        public CreateUserCommandHandler(IUserFactory userFactory, IRepository<User> repository)
        {
            _userFactory = userFactory;
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userFactory.CreateUserAsync(request);
            await _repository.CreateAsync(user);
            return Unit.Value;
        }
    }

}
