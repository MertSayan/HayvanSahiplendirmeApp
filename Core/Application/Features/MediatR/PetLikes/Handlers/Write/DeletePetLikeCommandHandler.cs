using Application.Features.MediatR.PetLikes.Commands;
using Application.Interfaces.PetLikeInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.PetLikes.Handlers.Write
{
    public class DeletePetLikeCommandHandler : IRequestHandler<DeletePetLikeCommand, Unit>
    {
        private readonly IPetLikeRepository _petLikeRepository;

        public DeletePetLikeCommandHandler(IPetLikeRepository petLikeRepository)
        {
            _petLikeRepository = petLikeRepository;
        }

        public async Task<Unit> Handle(DeletePetLikeCommand request, CancellationToken cancellationToken)
        {
            var petLike=await _petLikeRepository.GetPetLikeByIdAsync(request.UserId,request.PetId);
            await _petLikeRepository.DeletePetLikeAsync(petLike);
            return Unit.Value;
        }
    }
}
