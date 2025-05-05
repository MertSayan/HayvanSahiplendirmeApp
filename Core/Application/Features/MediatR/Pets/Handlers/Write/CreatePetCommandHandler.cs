using Application.Features.MediatR.Pets.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Pets.Handlers.Write
{
    public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand,Unit>
    {
        private readonly IRepository<Pet> _repository;
        private readonly IMapper _mapper;
        public CreatePetCommandHandler(IRepository<Pet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            var pet = _mapper.Map<Pet>(request);
            await _repository.CreateAsync(pet);
            return Unit.Value;
        }
    }
}
