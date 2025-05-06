using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.PetComments.Commands
{
    public class DeletePetCommentCommand : IRequest<Unit>
    {
        public int PetCommentId { get; set; }

        public DeletePetCommentCommand(int petCommentId)
        {
            PetCommentId = petCommentId;
        }
    }
}
