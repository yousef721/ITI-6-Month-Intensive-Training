using System;

namespace Lap05;

public static class DateTimeExtensions
{
    public static string ToFriendlyDate(this DateTime date)
    {
        var today = DateTime.Today;

        if (date.Date == today)
            return "Today";

        if (date.Date == today.AddDays(-1))
            return "Yesterday";

        if (date.Date == today.AddDays(1))
            return "Tomorrow";

        return date.ToString("dd/MM/yyyy");
    }
}