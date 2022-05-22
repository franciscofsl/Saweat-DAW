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
        var creationTask =  booking.BookingId > 0 
            ? repository.UpdateAsync(booking, cancellationToken) 
            : repository.InsertAsync(booking, cancellationToken);
        await creationTask;
        await this._unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<Booking>.CreateResponse(booking);
    }
}
