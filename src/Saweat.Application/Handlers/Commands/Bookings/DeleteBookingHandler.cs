namespace Saweat.Application.Handlers.Commands.Bookings;

public class DeleteBookingHandler : IRequestHandler<DeleteBookingRequest, Response<Booking>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBookingHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<Response<Booking>> Handle(DeleteBookingRequest request, CancellationToken cancellationToken)
    {
        var booking = request.Booking;
        var repository = this._unitOfWork.GetRepository<Booking>();
        await repository.DeleteAsync(booking, cancellationToken);
        await this._unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<Booking>.CreateResponse(booking);
    }
}
