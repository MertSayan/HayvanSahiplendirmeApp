using Application.Features.MediatR.PetLikes.Commands;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Factories
{
    public interface IPetLikesFactory
    {
        PetLike CreatePetLike(CreatePetLikeCommand request);
    }
}
