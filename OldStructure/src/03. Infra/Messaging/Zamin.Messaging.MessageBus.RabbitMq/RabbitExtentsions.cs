using Zamin.Utilities.Services.MessageBus;
using System.Text;
using RabbitMQ.Client.Events;
using Zamin.Utilities.Extensions;

namespace Zamin.Messaging.MessageBus.RabbitMq;
static class RabbitExtentsions
{
    public static Parcel ToParcel(this BasicDeliverEventArgs basicDeliverEventArgs)
    {
        Parcel parcel = new Parcel
        {
            CorrelationId = basicDeliverEventArgs?.BasicProperties?.CorrelationId,
            MessageId = basicDeliverEventArgs?.BasicProperties.MessageId,
            Route = basicDeliverEventArgs.RoutingKey,
            MessageBody = Encoding.UTF8.GetString(basicDeliverEventArgs.Body.ToArray()),
            MessageName = basicDeliverEventArgs.BasicProperties.Type,
            Headers = basicDeliverEventArgs?.BasicProperties?.Headers != null ? (Dictionary<string, object>)basicDeliverEventArgs?.BasicProperties?.Headers : null
        };
        return parcel;
    }

    public static string? GetAccuredByUserId(this Dictionary<string, object> value)
    {
        var userIdByte = (byte[]?)value.FirstOrDefault(e => e.Key == "AccuredByUserId").Value;
        return userIdByte.ByteArrayToString();
    }

    public static string? GetAccuredByUserIp(this Dictionary<string, object> value)
    {
        var userIdByte = (byte[]?)value.FirstOrDefault(e => e.Key == "AccuredByUserIp").Value;
        return userIdByte.ByteArrayToString();
    }

    public static string? GetAccuredByUserAgent(this Dictionary<string, object> value)
    {
        var userIdByte = (byte[]?)value.FirstOrDefault(e => e.Key == "AccuredByUserAgent").Value;
        return userIdByte.ByteArrayToString();
    }
}
