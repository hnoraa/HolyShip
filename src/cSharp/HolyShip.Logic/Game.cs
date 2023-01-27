using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic
{
    public class Game
    {
        public Map gameMap { get; set; }

        public Ship playerShip { get; set; }

        private bool _isRunning;

        private string _currentCommand;

        public Game() 
        {
            gameMap = new Map(20, 20);
            playerShip = new Ship(9, 19, Enums.Direction.North);
            
            gameMap.CreateMap(playerShip);

            _isRunning = true;
            _currentCommand = "";
        }

        public void MainLoop()
        {
            while(_isRunning)
            {
                // normally this is events, updates, renders (historically speaking)
                // update 
                Update();

                // render
                Render();

                // get events
                Events();
            }
        }

        public void Events()
        {
            _currentCommand = Console.ReadLine().ToLowerInvariant();

            if(!string.IsNullOrEmpty(_currentCommand) )
            {
                if(_currentCommand.StartsWith("q"))
                {
                    _isRunning = false;
                    //return;
                }
                else
                {
                    // handle events
                    if (!_currentCommand.Contains(",") && _currentCommand[0] != 'n' && _currentCommand[0] != 's' && _currentCommand[0] != 'w' && _currentCommand[0] != 'e')
                    {
                        Console.WriteLine("Invalid Command!");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Tuple<string, string> command = Tuple.Create(_currentCommand.Split(",")[0], _currentCommand.Split(",")[1]);
                        int steps = 0;

                        if (!Int32.TryParse(command.Item2, out steps))
                        {
                            Console.WriteLine("Invalid Command!");
                        }
                        else
                        {
                            // check to see if num steps exceeds ships max steps

                            // if ship is resting update rest turns left
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

                            playerShip.Move(direction, steps, gameMap.grid.GetLength(0), gameMap.grid.GetLength(1));
                        }
                    }
                }
            }
        }

        public void Update()
        {
            // get ship coordinates
            gameMap.CreateMap(playerShip);
        }

        public void Render()
        {
            Console.Clear();
            gameMap.DrawMap(playerShip);
            if(playerShip.IsResting())
            {
                Console.WriteLine($"Ship is in rest. Waiting {playerShip.TurnsLeft()} turns");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Type the direction and distance (ex: N,5 > move North 5 paces)");
            }
            Console.WriteLine("Press q to quit...");
        }
    }
}
