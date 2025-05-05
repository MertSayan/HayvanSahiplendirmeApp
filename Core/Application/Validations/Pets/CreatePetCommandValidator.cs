using Application.Features.MediatR.Pets.Commands;
using FluentValidation;

namespace Application.Validations.Pets
{
    public class CreatePetCommandValidator:AbstractValidator<CreatePetCommand>
    {
        public CreatePetCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad boş olamaz.")
            .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olabilir.")
            .Matches(@"^[a-zA-ZçÇğĞıİöÖşŞüÜ\s]+$").WithMessage("Hayvan adı sadece harf ve boşluk içermelidir.");

            RuleFor(x => x.Age)
                .NotEmpty().WithMessage("Yaş bilgisi zorunludur.");

            RuleFor(x => x.PetTypeId)
                .GreaterThan(0).WithMessage("Geçerli bir hayvan türü seçmelisiniz.");

            RuleFor(x => x.MainImageUrl)
                .NotEmpty().WithMessage("Bir görsel yüklemelisiniz.");
        }
    }
}
