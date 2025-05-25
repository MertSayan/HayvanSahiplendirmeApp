using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Pets.Results
{
    public class GetFeaturedPetQueryResult
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string MainImageUrl { get; set; }
        public int LikeCount { get; set; }
        public string Description { get; set; }
        public string PetTypeName { get; set; }
        public string Age { get; set; }
    }
}
