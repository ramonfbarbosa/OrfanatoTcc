using FluentValidation;
using OrfanatoAPI.Models;

namespace OrfanatoAPI.Validators;

public class ImagensValidator : AbstractValidator<Imagens>
{
    public ImagensValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(0)
            .WithMessage("O Id não pode ser nulo!");
        RuleFor(x => x.ImagemUrl)
            .NotEmpty()
            .WithMessage("O campo imagem não pode ficar vazio!")
            .NotNull()
            .WithMessage("O campo imagem não pode ser nulo!");
        RuleFor(x => x.Orfanato)
            .NotEmpty()
            .WithMessage("O campo orfanato não pode ficar vazio!")
            .NotNull()
            .WithMessage("O campo orfanato não pode ser nulo!");
    }
}
