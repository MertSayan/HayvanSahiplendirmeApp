using Application.Factories;
using Application.Features.MediatR.PetLikes.Commands;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Factories
{
    public class PetLikeFactory : IPetLikesFactory
    {
        private readonly IMapper _mapper;

        public PetLikeFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PetLike CreatePetLike(CreatePetLikeCommand request)
        {
            return _mapper.Map<PetLike>(request);
        }
    }
}
