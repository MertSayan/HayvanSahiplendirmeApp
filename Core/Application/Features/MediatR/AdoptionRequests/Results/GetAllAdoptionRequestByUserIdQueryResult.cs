using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.AdoptionRequests.Results
{
    public class GetAllAdoptionRequestByUserIdQueryResult
    {
        public int AdoptionRequestId { get; set; }
        public int PetId { get; set; }
        public string PetName { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string Status { get; set; }
        public string? Note { get; set; }
    }
}
