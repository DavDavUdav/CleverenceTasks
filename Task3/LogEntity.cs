namespace Task3
{
    public class LogEntity
    {
        public string Date { get; private set; }
        public string Time { get; private set; }
        public string Level { get; private set; }
        public string CallerMethod { get; private set; }
        public string Message { get; private set; }

        public LogEntity(string date, string time, string level, string callerMethod, string message)
        {
            Date = date;
            Time = time;
            Level = level;
            CallerMethod = callerMethod;
            Message = message;
        }

        public LogEntity(string date, string time, string level, string message) : this(date, time,level,"DEFAULT", message)
        {
        }

        public override string ToString()
        {
            return $"{Date}\t{Time}\t{Level}\t{CallerMethod}\t{Message}";
        }
    }
}
