namespace Task2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(0, 100, i => {
                if (i % 10 == 0)
                    Server.AddToCount(1);
                else
                    Console.WriteLine(Server.GetCount());
            });
        }
    }
}
