namespace Saweat.Application.Handlers.Commands.Bookings;

public class UpdateBookingHandler : IRequestHandler<UpdateBookingRequest, Response<Booking>>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IValidator<Booking> _validator;

    public UpdateBookingHandler(IUnitOfWork unitOfWork, IValidator<Booking> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Response<Booking>> Handle(UpdateBookingRequest request, CancellationToken cancellationToken)
    {
        var booking = request.Booking;
        var validationResult = await _validator.ValidateAsync(booking, cancellationToken);
        if (validationResult.Errors.Any())
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage);
            return Response<Booking>.CreateResponse(booking, false, errors);
        }
        var repository = _unitOfWork.GetRepository<Booking>();

        if (booking.BookingId > 0) await repository.UpdateAsync(booking, cancellationToken);
        else await repository.InsertAsync(booking, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<Booking>.CreateResponse(booking);
    }
}
