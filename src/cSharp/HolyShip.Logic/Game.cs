using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HolyShip.Logic.Enums;

namespace HolyShip.Logic
{
    public class Game
    {
        public Map gameMap { get; set; }

        public Ship playerShip { get; set; }

        private bool _isRunning;

        private string _currentCommandString;
        private Tuple<string, string>? _command;

        public Game() 
        {
            gameMap = new Map(20, 35);
            playerShip = new Ship(9, 19, Enums.Direction.North);
            
            gameMap.CreateMap(playerShip);

            _isRunning = true;
            _currentCommandString = "";
            _command = null;
        }

        public void MainLoop()
        {
            Update();
            Render();

            while (_isRunning)
            {
                // get events
                Events();

                // update 
                Update();

                // render
                Render();
            }
        }

        public void Events()
        {
            _currentCommandString = Console.ReadLine().ToLowerInvariant();

            if(!string.IsNullOrEmpty(_currentCommandString) || playerShip.IsResting())
            {
                if (_currentCommandString.StartsWith("q"))
                {
                    _isRunning = false;
                }
                else
                {
                    if(playerShip.IsResting())
                    {
                        playerShip.TakeRestTurn();
                        return;
                    }

                    if (!_currentCommandString.Contains(',') 
                        && _currentCommandString[0] != 'n'
                        && _currentCommandString[0] != 's' 
                        && _currentCommandString[0] != 'w' 
                        && _currentCommandString[0] != 'e')
                    {
                        Console.WriteLine("Invalid Command!");
                        Console.ReadKey();
                    }
                    else
                    {
                        _command = Tuple.Create(_currentCommandString.Split(",")[0], _currentCommandString.Split(",")[1]);
                        int steps = 0;

                        if (!Int32.TryParse(_command.Item2, out steps))
                        {
                            Console.WriteLine("Invalid Command!");
                            Console.ReadKey();
                        }
                        else
                        {
                            // check to see if num steps exceeds ships max steps
                            if (steps > playerShip.TurnsLeft())
                            {
                                Console.WriteLine($"You have {playerShip.TurnsLeft()} turns left before rest");
                                Console.ReadKey();
                            }
                            else
                            {
                                Enums.Direction direction = Enums.Direction.North;

                                if (_command.Item1.Equals("s"))
                                {
                                    direction = Enums.Direction.South;
                                }
                                else if (_command.Item1.Equals("w"))
                                {
                                    direction = Enums.Direction.West;
                                }
                                else if (_command.Item1.Equals("e"))
                                {
                                    direction = Enums.Direction.East;
                                }

                                playerShip.Move(direction, steps, gameMap.grid.GetLength(0), gameMap.grid.GetLength(1));
                            }
                        }
                    }
                }
            }
        }

        public void Update()
        {
            // update map
            gameMap.CreateMap(playerShip);
        }

        public void Render()
        {
            Console.Clear();
            gameMap.DrawMap(playerShip);
            if(playerShip.IsResting())
            {
                Console.WriteLine($"Ship resting. Waiting {playerShip.RestTurnsLeft()} turns...");
            }
            else
            {
                Console.WriteLine("Type the direction and distance (ex: N,5 > move North 5 paces)");
            }
            Console.WriteLine("Press q to quit...");
            Thread.Sleep(1000);
        }
    }
}
