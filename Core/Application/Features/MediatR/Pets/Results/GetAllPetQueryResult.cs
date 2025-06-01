using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Pets.Results
{
    public class GetAllPetQueryResult
    {
        public int PetId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string PetTypeName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
