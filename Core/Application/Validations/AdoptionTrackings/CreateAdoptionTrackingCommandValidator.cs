using Application.Features.MediatR.AdoptionTrackings.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations.AdoptionTrackings
{
    public class CreateAdoptionTrackingCommandValidator:AbstractValidator<CreateAdoptionTrackingCommand>
    {
        public CreateAdoptionTrackingCommandValidator()
        {
            RuleFor(x => x.AdoptionRequestId)
                .GreaterThan(0).WithMessage("Geçerli bir AdoptionRequestId girilmelidir.");

            RuleFor(x => x.WeekNumber)
                .GreaterThan(0).WithMessage("Hafta numarası 0'dan büyük olmalıdır.");

            RuleFor(x => x.PhotoImageUrl)
                .NotEmpty().WithMessage("Fotoğraf URL'si boş bırakılamaz.")
                .MaximumLength(300).WithMessage("Fotoğraf URL'si en fazla 300 karakter olabilir.");

            RuleFor(x => x.Note)
                .MaximumLength(500).WithMessage("Not en fazla 500 karakter olabilir.");
        }
    }
}
