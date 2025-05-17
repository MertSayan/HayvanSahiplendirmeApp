using Application.Features.MediatR.Pets.Queries;
using Application.Features.MediatR.Pets.Results;
using Application.Interfaces;
using Application.Interfaces.PetInterface;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Pets.Handlers.Read
{
    public class GetAllFilterPetQueryHandler : IRequestHandler<GetAllFilterPetQuery, List<GetAllFilterPetQueryResult>>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;
        public GetAllFilterPetQueryHandler(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllFilterPetQueryResult>> Handle(GetAllFilterPetQuery request, CancellationToken cancellationToken)
        {
            var pets = await _petRepository.GetFilteredPetsAsync(request);
            return _mapper.Map<List<GetAllFilterPetQueryResult>>(pets);
        }
    }
}
