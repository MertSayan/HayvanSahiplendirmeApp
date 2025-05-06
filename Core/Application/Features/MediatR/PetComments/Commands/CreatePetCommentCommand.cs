using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.PetComments.Commands
{
    public class CreatePetCommentCommand : IRequest<Unit>
    {
        public int PetId { get; set; }
        public int UserId { get; set; }
        public string CommentText { get; set; }
    }
}
