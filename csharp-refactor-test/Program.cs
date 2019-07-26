using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace csharp_refactor_test
{
    class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }

        private static void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Guess the magic word");

            var data = getData().GetAwaiter().GetResult();
            var output = ProcessData(data);
            var results = new List<bool>();

            foreach (var n in output)
            {
                Console.WriteLine("Guess the letter:");

                var letter = Console.ReadKey().Key;

                if (letter.ToString()[0] == n)
                    results.Add(true);
                else
                    results.Add(false);

                Console.WriteLine();
            }

            var isValid = true;

            foreach (var r in results)
            {
                if (r == true && isValid == true)
                    isValid = true;
                else if (r == true && isValid == false)
                    isValid = false;
                else if (r == false && isValid == true)
                    isValid = false;
                else if (r == false && isValid == false)
                    isValid = false;
            }

            PrintResult(isValid);

            Console.WriteLine("Continue? (y/n)");

            if (Continue())
                StartGame();
        }

        private static async Task<string> getData()
        {
            return "HOLA";
        }

        private static char[] ProcessData(string Data) => Data.ToCharArray();

        private static void PrintResult(bool isValid)
        {
            if (isValid)
                Console.WriteLine("WINNER");
            else
                Console.WriteLine("LOSER");
        }

        private static bool Continue() => Console.ReadKey().Key == ConsoleKey.Y ? true : false;
    }
}
