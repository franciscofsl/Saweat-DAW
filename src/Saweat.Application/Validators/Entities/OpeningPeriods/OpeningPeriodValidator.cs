namespace Saweat.Application.Validators.Entities.OpeningPeriods;

public class OpeningPeriodValidator : AbstractValidator<OpeningPeriod>
{
    private readonly IRepository<OpeningPeriod> _repository;

    public OpeningPeriodValidator(IRepository<OpeningPeriod> repository)
    {
        _repository = repository;
        RuleFor(u => u.StartHour)
            .LessThan(u => u.EndHour)
            .WithMessage("La fecha fin no puede ser anterior a la fecha de comienzo.");

        RuleFor(e => e)
            .MustAsync(CoincidantPeriodAsync)
            .WithMessage("El horario que intenta crear se esta solapando con otro horario.");
    }

    private async Task<bool> CoincidantPeriodAsync(OpeningPeriod openingPeriod, CancellationToken token)
    {
        var periods = await _repository.GetAllAsync(filter: p => p.OpeningId != openingPeriod.OpeningId, token: token);
        return !periods.Any(p => p.Day == openingPeriod.Day &&
                                 openingPeriod.StartHour.Between(p.StartHour, p.EndHour) &&
                                 openingPeriod.EndHour.Between(p.StartHour, p.EndHour));
    }
}
