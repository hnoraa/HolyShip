using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic
{
    public class Map
    {
        public char[,] grid { get; set; }
        
        public string windDirection { get; set; }

        public double windSpeed { get; set; }

        public Map(int x, int y)
        {
            grid = new char[x, y];
            ChangeWindDirection();
            ChangeWindSpeed();
        }

        private void ChangeWindDirection()
        {
            windDirection = HolyShip.Logic.Math.GetRandomDirection();
        }

        private void ChangeWindSpeed()
        {
            windSpeed = HolyShip.Logic.Math.RandomDouble(0, 40);
        }

        public void CreateMap(Ship ship)
        {
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    if (y == ship.posY && x == ship.posX)
                    {
                        if(ship.direction == Enums.Direction.North)
                        {
                            grid[y, x] = '^';
                        }
                        else if(ship.direction == Enums.Direction.South)
                        {
                            grid[y, x] = 'v';
                        }
                        else if(ship.direction == Enums.Direction.West)
                        {
                            grid[y, x] = '<';
                        } 
                        else
                        {
                            grid[y, x] = '>';
                        }
                    }
                    else
                    {
                        grid[y, x] = '~';
                    }
                }
            }
        }

        public void DrawMap(Ship ship)
        {
            Console.WriteLine("Map");
            Console.Write("+");
            Console.Write(new string('-', (grid.GetLength(0)*2) -1));
            Console.WriteLine("+");
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                Console.Write('|');
                Console.BackgroundColor = ConsoleColor.Blue;
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    if(y == ship.posY && x == ship.posX)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    } 
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    if(x < grid.GetLength(1)-1)
                    {
                        Console.Write(grid[y, x] + " ");
                    }
                    else
                    {
                        Console.Write(grid[y, x]);
                    }
                }
                Console.ResetColor();
                Console.WriteLine("|");
            }
            Console.Write("+");
            Console.Write(new string('-', (grid.GetLength(0) * 2) - 1));
            Console.WriteLine("+");
            Console.WriteLine($"Wind Speed: {windSpeed.ToString("#.00")} | Wind Direction: {windDirection} | ShipDirection: {ship.direction}");
        }
    }
}
