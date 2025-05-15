using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Pets.Results
{
    public class GetAllActivePetByOwnerIdQueryResult
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string PetTypeName { get; set; }
        public string Age { get; set; }
        public string Description { get; set; }
        public string MainImageUrl { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
