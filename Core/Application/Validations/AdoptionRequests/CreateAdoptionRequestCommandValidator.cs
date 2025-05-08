using Application.Enums;
using Application.Features.MediatR.AdoptionRequests.Commands;
using FluentValidation;

namespace Application.Validations.AdoptionRequests
{
    public class CreateAdoptionRequestCommandValidator:AbstractValidator<CreateAdoptionRequestCommand>
    {
        public CreateAdoptionRequestCommandValidator()
        {
            RuleFor(x => x.PetId)
                .GreaterThan(0).WithMessage("Geçerli bir PetId girilmelidir.");

            RuleFor(x => x.SenderId)
                .GreaterThan(0).WithMessage("Geçerli bir gönderici (SenderId) girilmelidir.");

            RuleFor(x => x.OwnerId)
                .GreaterThan(0).WithMessage("Geçerli bir sahip (OwnerId) girilmelidir.");

            //RuleFor(x => x.Status)
            //    .Must(s => Enum.TryParse(typeof(AdoptionStatus), s, true, out _))
            //    .WithMessage("Status değeri geçerli bir AdoptionStatus olmalıdır.");

            RuleFor(x => x.Note)
                .MaximumLength(250).WithMessage("Not en fazla 250 karakter olabilir.");
        }
    }
}
