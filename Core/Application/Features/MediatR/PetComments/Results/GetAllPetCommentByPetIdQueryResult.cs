using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.PetComments.Results
{
    public class GetAllPetCommentByPetIdQueryResult
    {
        public int PetCommentId { get; set; }
        public string PetName { get; set; }
        public string UserName { get; set; }
        public string UserImageUrl { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CommentText { get; set; }
    }
}
