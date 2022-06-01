namespace Saweat.Application.Validators.Entities.News;

public class NewValidator : AbstractValidator<New>
{
    public NewValidator()
    {
        RuleFor(n => n.Title)
            .NotEmpty()
            .WithMessage("La noticia no tiene titulo.");

        RuleFor(n => n.Content)
            .NotEmpty()
            .WithMessage("La noticia no tiene contenido.");

        RuleFor(n => n.Photo)
            .NotEmpty()
            .WithMessage("No se ha incluido una imagen.");
    }
}
