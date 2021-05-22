using System;

namespace GameOfDice
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Utils.ValidateArgs(args))
            {
                Console.WriteLine("Invalid Arguments. Please run the programs again.");
                return;
            }
            int totalPlayers = Utils.ConvertStringToPositiveInteger(args[0]);
            int targetPoints = Utils.ConvertStringToPositiveInteger(args[1]);
            Console.WriteLine("Welcome to Game of Dice!");
            Console.WriteLine($"Total Player: {totalPlayers}");
            Console.WriteLine($"Target Points: {targetPoints}");
            Game game = new Game(totalPlayers, targetPoints);
            game.StartGame();
            return;
        }
    }
}
