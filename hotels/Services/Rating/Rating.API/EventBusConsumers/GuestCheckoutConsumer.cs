using AutoMapper;
using Common.EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Rating.Application.Features.Ratings.Commands.CreateRatingProcess;

namespace Rating_API.EventBusConsumers;

public class GuestCheckoutConsumer : IConsumer<GuestCheckoutEvent>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<GuestCheckoutConsumer> _logger;

    public GuestCheckoutConsumer(IMediator mediator, IMapper mapper, ILogger<GuestCheckoutConsumer> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Consume(ConsumeContext<GuestCheckoutEvent> context)
    {
         try
         {
             _logger.LogInformation("Received context message: {MessageId}", context.Message.ReservationId);
             var command = _mapper.Map<CreateRatingProcessCommand>(context.Message);             
             _logger.LogInformation("Mapped command: {CommandId}", command.ReservationId);

             await _mediator.Send(command);

             _logger.LogInformation("Consume {Event} consumed successfully", nameof(GuestCheckoutEvent));
         }
         catch (Exception ex)
         {
             _logger.LogError(ex, "Error consuming message {MessageId}", context.Message.ReservationId);
             throw;
         }
    }
}
