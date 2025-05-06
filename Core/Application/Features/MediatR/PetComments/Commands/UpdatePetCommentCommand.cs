using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.PetComments.Commands
{
    public class UpdatePetCommentCommand : IRequest<Unit>
    {
        public int PetCommentId { get; set; }
        public int PetId { get; set; }
        public int UserId { get; set; }
        public string CommentText { get; set; }
    }
}
