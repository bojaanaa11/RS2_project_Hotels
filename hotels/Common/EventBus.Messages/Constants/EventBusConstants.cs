namespace Common.EventBus.Messages.Constants;

public static class EventBusConstants
{
    public const string guestcheckout_rating_queue = "guestcheckout-queue-rating-consumer";
    public const string guestcheckout_reservations_queue = "guestcheckout-queue-reservations-consumer";
    public const string guestcheckout_exchangename = "guestcheckout-fanout";

    public const string guestcheckout_exchangetype = "fanout";
}