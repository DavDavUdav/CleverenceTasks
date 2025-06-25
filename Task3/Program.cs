namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LogHandler logHandler = new LogHandler();
            while (true)
            {
                logHandler.Handle();
            }
        }
    }
}
