using Application.Enums;
using Application.Features.MediatR.AdoptionRequests.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.AdoptionRequests.Handlers.Write
{
    public class UpdateAdoptionRequestAccpetCommandHandler : IRequestHandler<UpdateAdoptionRequestAcceptCommand, Unit>
    {
        private readonly IRepository<AdoptionRequest> _repository;
        private readonly IRepository<Pet> _petRepository;
        private readonly IMapper _mapper;
        public UpdateAdoptionRequestAccpetCommandHandler(IRepository<AdoptionRequest> repository, IMapper mapper, IRepository<Pet> petRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _petRepository = petRepository;
        }

        public async Task<Unit> Handle(UpdateAdoptionRequestAcceptCommand request, CancellationToken cancellationToken)
        {
            var adoptionRequest = await _repository.GetByIdAsync(request.Id);
            adoptionRequest.Status=AdoptionStatus.Accepted.ToString();
            await _repository.UpdateAsync(adoptionRequest);

            var pet = await _petRepository.GetByIdAsync(adoptionRequest.PetId);
            pet.IsAdopted = true;
            await _petRepository.UpdateAsync(pet);

            return Unit.Value;
        }
    }
}
