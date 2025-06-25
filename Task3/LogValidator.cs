namespace Task3
{
    public class LogValidator
    {
        public string? ValidateLogType1(string fileData)
        {
            string[] data = fileData.Split('|', 5);
            string[] dateTime = data[0].Split(' ');

            bool CompleteParseData = DateTime.TryParse(dateTime[0], out DateTime dateResult);
            if (!CompleteParseData)
            {
                return null;
            }

            string? date = ValidateDate(dateTime[0]);
            if (date == null)
            {
                return null;
            }

            string time = dateTime[1];

            string? level = ValidateLevel(data[1].Trim());
            if (level == null)
            {
                return null;
            }

            string callerMethod = data[3].Trim();
            string message = data[4].Trim();
            return new LogEntity(date, time, level, callerMethod, message).ToString();
        }

        public string? ValidateLogType2(string fileData)
        {
            string[] data = fileData.Split(' ', 4);

            string? date = ValidateDate(data[0]);
            if (date == null)
            {
                return null;
            }
            string time = data[1];
            string? level = ValidateLevel(data[2]);
            if (level == null)
            {
                return null;
            }
            string message = data[3];
            return new LogEntity(date, time, level, message).ToString();
        }

        private string? ValidateDate(string date)
        {
            bool complete = DateTime.TryParse(date, out DateTime dateResult);
            if (!complete)
            {
                return null;
            }
            return dateResult.ToString("dd-MM-yyyy");
        }

        private string? ValidateLevel(string level)
        {
            switch (level)
            {
                case "INFORMATION":
                case "INFO":
                    return "INFO";
                case "WARNING":
                case "WARN":
                    return "WARN";
                case "DEBUG":
                case "ERROR":
                    return level;
                default:
                    return null;
            }
        }
    }
}
