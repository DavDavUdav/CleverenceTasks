using System.Text;

namespace TestTask
{
    public class Task1
    {
        static void Main(string[] args)
        {
            string input = "sssaasffatw";
            string compressionResult = Compression(input);
            Console.WriteLine("InputString: " + input);
            Console.WriteLine("Compression result: "+ compressionResult);
            Console.WriteLine("Decompression result: " + Decompression(compressionResult));
        }

        public static string Compression(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                return string.Empty;
            }

            char currentChar = inputString[0];
            int count = 0;

            StringBuilder sb = new StringBuilder();
            foreach (char c in inputString)
            {
                if (currentChar == c)
                {
                    count++;
                }
                else
                {
                    sb.Append(currentChar);
                    if (count > 1)
                    {
                        sb.Append(count);
                    }

                    currentChar = c;
                    count = 1;
                }
            }

            sb.Append(currentChar);
            if (count > 1)
            {
                sb.Append(count);
            }

            return sb.ToString();
        }

        public static string Decompression(string inputString)
        {
            if(string.IsNullOrEmpty(inputString))
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();

            int i = 0;
            while (i < inputString.Length)
            {
                char symbol = inputString[i++];
                int count = 0;

                StringBuilder numberString = new();
                while (i < inputString.Length && char.IsDigit(inputString[i]))
                {
                    numberString.Append(inputString[i++]);
                }
                count = numberString.Length == 0 ? 1 : Int32.Parse(numberString.ToString());
                sb.Append(symbol, count);
            }
            return sb.ToString();
        }
    }
}
