using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.AdoptionRequests.Results
{
    public class GetAllIncomingAdoptionByOwnerIdQueryResult
    {
        public int AdoptionRequestId { get; set; }
        public string PetName { get; set; }
        public string SenderName { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
