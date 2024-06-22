using AutoMapper;
using Common.EventBus.Messages.Events;
using MassTransit;
using Reservations.Common.Repositories;

namespace Reservations.EventBusConsumers;

public class GuestCheckoutConsumer : IConsumer<GuestCheckoutEvent>
{
    IReservationRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<GuestCheckoutConsumer> _logger;

    public GuestCheckoutConsumer(IReservationRepository repository, IMapper mapper, ILogger<GuestCheckoutConsumer> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Consume(ConsumeContext<GuestCheckoutEvent> context)
    {
         try
         {
             _logger.LogInformation("Received context message: {MessageId}", context.Message.ReservationId);
             
             _repository.DeleteReservation(context.Message.ReservationId);

             _logger.LogInformation("Consume {Event} consumed successfully", nameof(GuestCheckoutEvent));
         }
         catch (Exception ex)
         {
             _logger.LogError(ex, "Error consuming message {MessageId}", context.Message.ReservationId);
             throw; // Rethrow the exception to ensure it is handled by MassTransit
         }
    }
}
