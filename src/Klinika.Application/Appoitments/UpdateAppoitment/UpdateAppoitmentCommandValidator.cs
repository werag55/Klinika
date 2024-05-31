using FluentValidation;
using Klinika.Application.Appoitments.UpdateAppoitment;
using Klinika.Application.Appoitments.CheckAppoitmentByDate;
using Klinika.Domain.Repositories;

public class UpdateAppoitmentCommandValidator : AbstractValidator<UpdateAppoitmentCommand>
{
    private readonly IAppoitmentRepository _appoitmentRepository;

    public UpdateAppoitmentCommandValidator(IAppoitmentRepository appoitmentRepository)
    {
        _appoitmentRepository = appoitmentRepository;

        RuleFor(x => x.Appoitment.Date)
            .Must(BeAValidDate)
            .WithMessage("Appointments can only be scheduled between 8:00 and 15:00, on the hour, Monday to Friday.")
            .MustAsync(HaveNoConflictingAppointments)
            .WithMessage("There is already an appointment at the given hour.");
    }

    private bool BeAValidDate(DateTime date)
    {
        if (date < DateTime.Now)
            return false;

        if (date.Hour < 8 || date.Hour > 15)
            return false;

        if (date.Minute != 0 || date.Second != 0 || date.Millisecond != 0 || date.Microsecond != 0 || date.Nanosecond != 0)
            return false;

        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            return false;

        return true;
    }

    private async Task<bool> HaveNoConflictingAppointments(DateTime date, CancellationToken cancellationToken)
    {
        var query = new CheckAppoitmentByDateQuery(date);
        var handler = new CheckAppoitmentByIdQueryHandler(_appoitmentRepository);
        var result = await handler.Handle(query, cancellationToken);

        return result != true;
    }
}