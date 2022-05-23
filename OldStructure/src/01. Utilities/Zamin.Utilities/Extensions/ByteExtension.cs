using System.Text;

namespace Zamin.Utilities.Extensions;

public static class ByteExtension
{
    public static string? ByteArrayToString(this byte[]? value)
    {
        if (value == null)
            return null;

        return Encoding.UTF8.GetString(value);
    }
}