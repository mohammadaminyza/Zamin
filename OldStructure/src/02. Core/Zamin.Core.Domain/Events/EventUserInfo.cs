namespace Zamin.Core.Domain.Events;

public class EventUserInfo
{
    public static string? UserId { get; set; }
    public static string? UserIp { get; set; }
    public static string? UserAgent { get; set; }

    public static void ClearInfo()
    {
        EventUserInfo.UserId = null;
        EventUserInfo.UserIp = null;
        EventUserInfo.UserAgent = null;
    }
}