using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> roverMovementInputs = new List<string>();

                for (int i = 0; i < 5; i++)
                {
                    roverMovementInputs.Add(Console.ReadLine());
                }

                List<int> areaBorder = roverMovementInputs[0].Trim().Split(' ').Select(int.Parse).ToList();

                for (int i = 1; i < roverMovementInputs.Count(); i+=2)
                {
                    string startPositions = roverMovementInputs[i].Trim().ToUpper();
                    string moves = roverMovementInputs[i+1].ToUpper();

                    Movements position = new Movements(startPositions);
                    position.Move(areaBorder, moves);
                    Console.WriteLine($"{position.X} {position.Y} {position.Direction}");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    
    }
}
