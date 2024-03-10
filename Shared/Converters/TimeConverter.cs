using System.Text.RegularExpressions;

namespace Shared.Converters
{
    public static class TimeConverter
    {
        public static int ConvertToSeconds(this string timeExpression)
        {
            timeExpression.Trim();
            int totalSeconds = 0;
            string pattern = @"(?<hours>\d+h)?\s*(?<minutes>\d+m)?\s*(?<seconds>\d+s)?";
            Match match = Regex.Match(timeExpression, pattern);

            if (match.Success)
            {
                if (match.Groups["hours"].Success)
                {
                    int hours = int.Parse(match.Groups["hours"].Value.TrimEnd('h'));
                    totalSeconds += hours * 3600;
                }

                if (match.Groups["minutes"].Success)
                {
                    int minutes = int.Parse(match.Groups["minutes"].Value.TrimEnd('m'));
                    totalSeconds += minutes * 60;
                }

                if (match.Groups["seconds"].Success)
                {
                    int seconds = int.Parse(match.Groups["seconds"].Value.TrimEnd('s'));
                    totalSeconds += seconds;
                }
            }
            return totalSeconds;
        }

    }
}
