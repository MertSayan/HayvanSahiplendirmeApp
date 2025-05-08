using Application.Features.MediatR.AdoptionRequests.Commands;
using FluentValidation;

namespace Application.Validations.AdoptionRequests
{
    public class UpdateAdoptionRequestCommandValidator:AbstractValidator<UpdateAdoptionRequestCommand>
    {
        public UpdateAdoptionRequestCommandValidator()
        {
            RuleFor(x => x.AdoptionRequestId)
                .GreaterThan(0).WithMessage("Geçerli bir AdoptionRequestId girilmelidir.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Status geçerli bir değer olmalıdır."); // çünkü enum tipinde

        }
    }
}
