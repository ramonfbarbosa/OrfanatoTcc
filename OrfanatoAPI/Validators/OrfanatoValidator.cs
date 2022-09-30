using FluentValidation;
using OrfanatoAPI.Models;

namespace OrfanatoAPI.Validators;

public class OrfanatoValidator : AbstractValidator<Orfanato>
{
    public OrfanatoValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(0)
            .WithMessage("O id não pode ser nulo!");
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O campo nome não pode ficar vazio!")
            .NotNull()
            .WithMessage("O campo nome não pode ser nulo!");
        RuleFor(x => x.Latitude)
            .NotEmpty()
            .WithMessage("O campo latitude não pode ficar vazio!")
            .NotNull()
            .WithMessage("O campo latitude não pode ser nulo!");
        RuleFor(x => x.Longitude)
            .NotEmpty()
            .WithMessage("O campo longitude não pode ficar vazio!")
            .NotNull()
            .WithMessage("O campo longitude não pode ser nulo!");
        RuleFor(x => x.Sobre)
            .NotEmpty()
            .WithMessage("O campo sobre não pode ficar vazio!")
            .NotNull()
            .WithMessage("O campo sobre não pode ser nulo!");
        RuleFor(x => x.Instrucoes)
            .NotEmpty()
            .WithMessage("O campo instrucoes não pode ficar vazio!")
            .NotNull()
            .WithMessage("O campo instrucoes não pode ser nulo!");
        RuleFor(x => x.HoraDeAbertura)
            .NotEmpty()
            .WithMessage("O campo hora de abertura não pode ficar vazio!")
            .NotNull()
            .WithMessage("O campo hora de abertura não pode ser nulo!");
        RuleFor(x => x.AbertoFimDeSemana)
            .Equal(true || false);
        RuleFor(x => x.Imagens)
            .NotEmpty()
            .WithMessage("O campo imagens não pode ficar vazio!")
            .NotNull()
            .WithMessage("O campo imagens não pode ser nulo!");
    }
}
