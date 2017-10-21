namespace HiRezApi.Common
{
    using System;
    using System.Globalization;
    using System.Security.Cryptography;
    using System.Text;

    public static class ConvertUtil
    {
        public static string ToApiParameterDate(this DateTime date)
        {
            return date.ToString("yyyyMMdd");
        }

        public static string ToApiParameterHourAndMinTime(this TimeSpan hour, TimeSpan? minute = null)
        {
            // HiRez API input should look like: "15,00" or "15" e.g.
            if (!minute.HasValue)
                return hour.ToApiParameterHourTime();

            var firstMinDigitStr = minute.Value.Minutes.ToString("D2")[0];
            var timeStr = $"{hour.ToApiParameterHourTime()},{firstMinDigitStr}0";
            return timeStr;
        }

        public static string ToApiParameterHourTime(this TimeSpan timeSpan)
        {
            return $"{timeSpan.Hours:D2}";
        }

        public static string ToMd5LowerInvariant(this string input)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                for (var i = 0; i < hashBytes.Length; i++)
                    sb.Append(hashBytes[i].ToString("X2").ToLowerInvariant());

                return sb.ToString();
            }
        }

        public static bool TryParseApiDate(this string dateStr, out DateTime dateTime)
        {
            if (DateTime.TryParseExact(dateStr, "M/d/yyyy h:mm:ss tt", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AssumeUniversal, out dateTime))
                return true;

            // Seconds try: Handle API inconsistency with DateTime formats
            if (DateTime.TryParseExact(dateStr, "dd/MM/yyyy h:mm:ss", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AssumeUniversal, out dateTime))
                return true;

            return false;
        }
    }
}