using Application.Features.MediatR.PetComments.Queries;
using Application.Features.MediatR.PetComments.Results;
using Application.Interfaces.PetCommentInterface;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.PetComments.Handlers.Read
{
    public class GetAllPetCommentByPetIdQueryHandler : IRequestHandler<GetAllPetCommentByPetIdQuery,List<GetAllPetCommentByPetIdQueryResult>>
    {
        private readonly IPetCommentRepository _repository;

        private readonly IMapper _mapper;
        public GetAllPetCommentByPetIdQueryHandler(IPetCommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllPetCommentByPetIdQueryResult>> Handle(GetAllPetCommentByPetIdQuery request, CancellationToken cancellationToken)
        {
            var petComment = await _repository.GetAllPetCommentByPetIdAsync(request.Id);

            return _mapper.Map<List<GetAllPetCommentByPetIdQueryResult>>(petComment);
        }

        
    }
}
