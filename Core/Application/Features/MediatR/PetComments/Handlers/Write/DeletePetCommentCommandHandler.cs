using Application.Features.MediatR.PetComments.Commands;
using Application.Features.MediatR.Pets.Commands;
using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.PetComments.Handlers.Write
{
    public class DeletePetCommentCommandHandler : IRequestHandler<DeletePetCommentCommand,Unit>
    {
        private readonly IRepository<PetComment> _repository;

        public DeletePetCommentCommandHandler(IRepository<PetComment> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePetCommentCommand request, CancellationToken cancellationToken)
        {
            var petComment = await _repository.GetByIdAsync(request.PetCommentId);
            await _repository.DeleteAsync(petComment);
            return Unit.Value;
        }

    }
}
