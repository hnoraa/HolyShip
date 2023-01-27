using HolyShip.Logic;
using System.ComponentModel.DataAnnotations;

bool running = true;
Map m = new Map(20, 20, 9, 19);

while (running)
{
    Console.Clear();
    m.CreateMap();
    m.DrawMap();

    Console.WriteLine("Type the direction and distance (ex: N,5 > move North 5 paces)");
    Console.WriteLine("Press q to quit...");
    string choice = Console.ReadLine().ToLowerInvariant();

    if (!string.IsNullOrEmpty(choice))
    {
        if (choice == "q")
        {
            running = false;
        }
        else if(!choice.Contains(",") && choice[0] != 'n' && choice[0] != 's' && choice[0] != 'w' && choice[0] != 'e')
        {
            Console.WriteLine("Invalid Command!");
            Thread.Sleep(1000);
        }
        else
        {
            Tuple<string, string> command = Tuple.Create(choice.Split(",")[0], choice.Split(",")[1]);
            int steps = 0;

            if(!Int32.TryParse(command.Item2, out steps))
            {
                Console.WriteLine("Invalid Command!");
            }
            else
            {
                Enums.Direction direction = Enums.Direction.North;
                if (command.Item1.Equals("s"))
                {
                    direction = Enums.Direction.South;
                }
                else if (command.Item1.Equals("w"))
                {
                    direction = Enums.Direction.West;
                }
                else if (command.Item1.Equals("e"))
                {
                    direction = Enums.Direction.East;
                }

                m.Move(direction, steps);
            }
        }
    }
}

Console.WriteLine("End of simulation...");