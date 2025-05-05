using Application.Features.MediatR.Pets.Commands;
using FluentValidation;

namespace Application.Validations.Pets
{
    public class UpdatePetCommandValidator:AbstractValidator<UpdatePetCommand>
    {
        public UpdatePetCommandValidator()
        {
            RuleFor(x => x.PetId)
                .GreaterThan(0).WithMessage("Geçerli bir PetId gönderilmelidir.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Hayvan adı boş olamaz.")
                .MaximumLength(50).WithMessage("Hayvan adı en fazla 50 karakter olabilir.")
                .Matches(@"^[a-zA-ZçÇğĞıİöÖşŞüÜ\s]+$").WithMessage("Hayvan adı sadece harf ve boşluk içermelidir.");

            RuleFor(x => x.Age)
                .NotEmpty().WithMessage("Yaş bilgisi boş olamaz.");

            RuleFor(x => x.PetTypeId)
                .GreaterThan(0).WithMessage("Geçerli bir hayvan türü seçmelisiniz.");

            RuleFor(x => x.MainImageUrl)
                .NotEmpty().WithMessage("Ana görsel URL'si zorunludur.");
        }
    }
}
