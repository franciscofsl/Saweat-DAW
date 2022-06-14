using Saweat.Domain.Enums;
using Saweat.Domain.Utils;

namespace Saweat.Application.Handlers.Commands.Bookings;

public class CancelBookingHandler : IRequestHandler<CancelBookingRequest, Response<bool>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CancelBookingHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<bool>> Handle(CancelBookingRequest request, CancellationToken cancellationToken)
    {
        var code = request.Code;
        var repository = _unitOfWork.GetRepository<Booking>();
        var bookingsResult = await repository.GetAllAsync(b => b.Code == code, token: cancellationToken);
        if (bookingsResult == null || !bookingsResult.Any())
        {
            return Response<bool>.CreateResponse(false);
        }

        var booking = bookingsResult.First();
        booking.State = BookingState.Cancel;
        await repository.UpdateAsync(booking, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<bool>.CreateResponse(true);

    }
}

public class CancelBookingRequest : IRequest<Response<bool>>
{
    public string  Code { get; set; }
}