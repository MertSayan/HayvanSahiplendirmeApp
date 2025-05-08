using Application.Features.MediatR.Pets.Results;
using Application.Features.MediatR.Users.Queries;
using Application.Features.MediatR.Users.Results;
using Application.Interfaces.PetInterface;
using Application.Interfaces.UserInterface;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Users.Handlers.Read
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, GetByIdUserQueryResult>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public GetByIdUserQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

       
        public async Task<GetByIdUserQueryResult> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdUserAsync(request.Id);

            return _mapper.Map<GetByIdUserQueryResult>(user);
        }
    }
}
