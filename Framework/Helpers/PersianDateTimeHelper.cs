using System.Globalization;

namespace Laboratory.Framework.Helpers;

/// <summary>
/// هلپر تخصصی تبدیل تاریخ میلادی انگلیسی (ذخیره در دیتابیس) به فرمت‌های استاندارد شمسی (نمایش در فرانت‌اند)
/// </summary>
public static class PersianDateTimeHelper
{
    private static readonly PersianCalendar Pc = new();

    /// <summary>
    /// تبدیل DateTime به رشته تاریخ و ساعت شمسی: 1405/06/07 11:30
    /// </summary>
    public static string ToPersianDateTimeString(this DateTime? dateTime, bool includeTime = true)
    {
        if (!dateTime.HasValue || dateTime.Value == DateTime.MinValue)
            return string.Empty;

        return ToPersianDateTimeString(dateTime.Value, includeTime);
    }

    public static string ToPersianDateTimeString(this DateTime dateTime, bool includeTime = true)
    {
        if (dateTime == DateTime.MinValue)
            return string.Empty;

        int year = Pc.GetYear(dateTime);
        int month = Pc.GetMonth(dateTime);
        int day = Pc.GetDayOfMonth(dateTime);

        if (!includeTime)
        {
            return $"{year:0000}/{month:00}/{day:00}";
        }

        int hour = Pc.GetHour(dateTime);
        int minute = Pc.GetMinute(dateTime);

        return $"{year:0000}/{month:00}/{day:00} - {hour:00}:{minute:00}";
    }

    /// <summary>
    /// تبدیل DateOnly به رشته تاریخ شمسی: 1405/06/07
    /// </summary>
    public static string ToPersianDateString(this DateOnly? dateOnly)
    {
        if (!dateOnly.HasValue)
            return string.Empty;

        return ToPersianDateString(dateOnly.Value);
    }

    public static string ToPersianDateString(this DateOnly dateOnly)
    {
        var dateTime = dateOnly.ToDateTime(TimeOnly.MinValue);
        int year = Pc.GetYear(dateTime);
        int month = Pc.GetMonth(dateTime);
        int day = Pc.GetDayOfMonth(dateTime);

        return $"{year:0000}/{month:00}/{day:00}";
    }

    /// <summary>
    /// تبدیل رشته تاریخ شمسی ورودی از فرانت‌اند به تاریخ میلادی استاندارد جهت ذخیره در SQL Server
    /// مثال: 1405/06/07 -> DateTime(2026, 08, 29)
    /// </summary>
    public static DateTime? ToGregorianDateTime(string? persianDateStr)
    {
        if (string.IsNullOrWhiteSpace(persianDateStr))
            return null;

        try
        {
            string clean = persianDateStr.Trim().Replace("-", "/").Replace(".", "/");
            var parts = clean.Split(new[] { '/', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 3) return null;

            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int day = int.Parse(parts[2]);

            int hour = 0, minute = 0, second = 0;
            if (parts.Length >= 4 && parts[3].Contains(':'))
            {
                var timeParts = parts[3].Split(':');
                hour = int.Parse(timeParts[0]);
                if (timeParts.Length > 1) minute = int.Parse(timeParts[1]);
                if (timeParts.Length > 2) second = int.Parse(timeParts[2]);
            }

            return Pc.ToDateTime(year, month, day, hour, minute, second, 0);
        }
        catch
        {
            return null;
        }
    }
}
