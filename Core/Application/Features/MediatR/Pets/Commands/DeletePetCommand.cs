using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Pets.Commands
{
    public class DeletePetCommand:IRequest<Unit>
    {
        public int Id { get; set; }

        public DeletePetCommand(int id)
        {
            Id = id;
        }
    }
}
