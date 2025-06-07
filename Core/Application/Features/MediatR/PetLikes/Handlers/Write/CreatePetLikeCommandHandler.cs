using Application.Factories;
using Application.Features.MediatR.PetLikes.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.PetLikes.Handlers.Write
{
    public class CreatePetLikeCommandHandler : IRequestHandler<CreatePetLikeCommand, Unit>
    {
        private readonly IRepository<PetLike> _repository;
        private readonly IPetLikesFactory _petLikeFactory;

        public CreatePetLikeCommandHandler(IRepository<PetLike> repository, IPetLikesFactory petLikeFactory)
        {
            _repository = repository;
            _petLikeFactory = petLikeFactory;
        }

        public async Task<Unit> Handle(CreatePetLikeCommand request, CancellationToken cancellationToken)
        {
            var petLike = _petLikeFactory.CreatePetLike(request);
            await _repository.CreateAsync(petLike);
            return Unit.Value;
        }
    }

}
