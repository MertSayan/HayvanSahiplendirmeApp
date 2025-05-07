using Application.Features.MediatR.AdoptionRequests.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.AdoptionRequests.Handlers.Write
{
    public class UpdateAdoptionRequestCommandHandler : IRequestHandler<UpdateAdoptionRequestCommand, Unit>
    {
        private readonly IRepository<AdoptionRequest> _repository;
        private readonly IMapper _mapper;
        public UpdateAdoptionRequestCommandHandler(IRepository<AdoptionRequest> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAdoptionRequestCommand request, CancellationToken cancellationToken)
        {
            var adoptionRequest=await _repository.GetByIdAsync(request.AdoptionRequestId);
            _mapper.Map(request, adoptionRequest);
            await _repository.UpdateAsync(adoptionRequest);
            return Unit.Value;
        }
    }
}
