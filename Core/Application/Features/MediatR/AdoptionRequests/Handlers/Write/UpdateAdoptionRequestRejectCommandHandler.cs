using Application.Enums;
using Application.Features.MediatR.AdoptionRequests.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.AdoptionRequests.Handlers.Write
{
    public class UpdateAdoptionRequestRejectCommandHandler:IRequestHandler<UpdateAdoptionRequestRejectCommand,Unit>
    {
        private readonly IRepository<AdoptionRequest> _repository;
        private readonly IMapper _mapper;
        public UpdateAdoptionRequestRejectCommandHandler(IRepository<AdoptionRequest> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAdoptionRequestRejectCommand request, CancellationToken cancellationToken)
        {
            var adoptionRequest = await _repository.GetByIdAsync(request.Id);
            adoptionRequest.Status = AdoptionStatus.Rejected.ToString();
            await _repository.UpdateAsync(adoptionRequest);
            return Unit.Value;
        }
    }
}
