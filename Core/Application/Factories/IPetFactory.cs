using Application.Features.MediatR.Pets.Commands;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Factories
{
    public interface IPetFactory
    {
        Task<Pet> CreatePetAsync(CreatePetCommand request);
    }
}
