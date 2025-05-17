using Application.Features.MediatR.Pets.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Pets.Queries
{
    public class GetAllFilterPetQuery:IRequest<List<GetAllFilterPetQueryResult>>
    {
        public int? PetTypeId { get; set; }
        public string? Age { get; set; }
        public string? City { get; set; }
        public string? Gender { get; set; }
        public bool? IsVaccinated { get; set; }
        public bool? IsNeutered { get; set; }

        public int Page { get; set; } = 1;         // varsayılan: 1. sayfa
        public int PageSize { get; set; } = 10;    // varsayılan: 10 kayıt
    }
}
