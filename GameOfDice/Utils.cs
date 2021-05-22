using System;

namespace GameOfDice
{
    public class Utils
    {
        // Returns -1 if not valid else converted positive integer.
        public static int ConvertStringToPositiveInteger(string number)
        {
            int n;
            bool isValid = int.TryParse(number, out n);
            if (n > 0 && isValid)
            {
                return n;
            }
            else
            {
                return -1;
            }
        }
        public static bool ValidateArgs(string[] args)
        {
            if (args.Length != 2) return false;
            if (ConvertStringToPositiveInteger(args[0]) > 0 && ConvertStringToPositiveInteger(args[1]) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int[] Get1ToNArray(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("n cannot be less than or equal to zero");
            }
            var array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = i + 1;
            }
            return array;
        }

        public static int[] GenerateOrder(int totalPlayers)
        {
            if (totalPlayers <= 0)
            {
                throw new ArgumentException("n cannot be less than or equal to zero");
            }
            var orderArray = new int[totalPlayers];
            var orderedArray = new bool[totalPlayers];
            var random = new Random();
            int i = 0;
            int counter = 0;
            Console.WriteLine("Player order: ");
            while (i < totalPlayers)
            {
                int playerNumber = random.Next(1, totalPlayers + 1);
                if (!orderedArray[playerNumber - 1])
                {
                    orderArray[i] = playerNumber;
                    orderedArray[playerNumber - 1] = true;
                    i++;
                    Console.Write($"{playerNumber} ");
                }
                counter++;
            }
            Console.WriteLine();
            Console.WriteLine($"Debug: Loop ran {counter} times");
            return orderArray;
        }
    }
}
