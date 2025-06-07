using Application.Enums;
using Application.Factories;
using Application.Features.MediatR.AdoptionRequests.Commands;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Factories
{
    public class AdoptionRequestFactory : IAdoptionRequestFactory
    {
        private readonly IMapper _mapper;

        public AdoptionRequestFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public AdoptionRequest CreateAdoptionRequest(CreateAdoptionRequestCommand request)
        {
            var adoptionRequest = _mapper.Map<AdoptionRequest>(request);

            // Varsayılan olarak Pending status atanıyor
            adoptionRequest.Status = AdoptionStatus.Pending.ToString();

            return adoptionRequest;
        }
    }
}
