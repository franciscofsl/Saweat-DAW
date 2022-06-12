using Saweat.Domain.Enums;

namespace Saweat.Application.Handlers.Commands.Bookings;

public class UpdateBookingHandler : IRequestHandler<UpdateBookingRequest, Response<Booking>>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IValidator<Booking> _validator;

    public UpdateBookingHandler(IUnitOfWork unitOfWork, IValidator<Booking> validator)
    {
        this._unitOfWork = unitOfWork;
        this._validator = validator;
    }

    public async Task<Response<Booking>> Handle(UpdateBookingRequest request, CancellationToken cancellationToken)
    {
        var booking = request.Booking;
        var validationResult = await this._validator.ValidateAsync(booking, cancellationToken);
        if (validationResult.Errors.Any())
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage);
            return Response<Booking>.CreateResponse(booking, false, errors);
        }

        var repository = this._unitOfWork.GetRepository<Booking>();
        booking.Code = await GetUnusedCode(booking.Code, repository, cancellationToken);

        if (booking.BookingId > 0)
        {
            await repository.UpdateAsync(booking, cancellationToken);
        }
        else
        {
            booking.State = BookingState.Pending;
            await repository.InsertAsync(booking, cancellationToken);
        }
        await this._unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<Booking>.CreateResponse(booking);
    }

    private static async Task<string> GetUnusedCode(string code, IRepository<Booking> repository,
        CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(code))
        {
            return code;
        }

        var existingCodes = (await repository.GetAllAsync(token: cancellationToken)).Select(b => b.Code);
        var temporalCode = string.Empty;
        while (temporalCode == string.Empty)
        {
            var generatedCode = Guid.NewGuid().ToString().Replace("-", "");
            if (!existingCodes.Any(c => c.Equals(generatedCode)))
            {
                temporalCode = generatedCode;
            }
        }

        return temporalCode;
    }
}