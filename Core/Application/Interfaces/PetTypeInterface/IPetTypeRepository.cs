using Application.Features.MediatR.PetTypes.Results;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.PetTypeInterface
{
    public interface IPetTypeRepository
    {
        Task<List<GetPetTypeDistributionQueryResult>> GetPetTypeDistributionAsync();
    }
}
