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
        // char[,] map = new char[20, 20];
        public char[,] grid { get; set; }
        
        public int shipX { get; set; }

        public int shipY { get; set; }

        public string windDirection { get; set; }

        public double windSpeed { get; set; }

        public string shipDirection { get; set; }

        public Map(int x, int y, int shipX, int shipY)
        {
            grid = new char[x, y];
            this.shipX = shipX;
            this.shipY = shipY;
            this.shipDirection = Enums.Direction.North.ToString();
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

        public void Move(Enums.Direction direction, int numSteps)
        {
            shipDirection = direction.ToString();

            switch (direction)
            {
                case Enums.Direction.North:
                case Enums.Direction.South:
                    int velY = direction == Enums.Direction.North ? -numSteps : numSteps;
                    if ((direction == Enums.Direction.North && (shipY + velY) >= 0) || (direction == Enums.Direction.South && (shipY + velY) <= grid.GetLength(1))) {
                        shipY += velY;
                    }
                    break;
                case Enums.Direction.West:
                case Enums.Direction.East:
                    int velX = direction == Enums.Direction.West ? -numSteps : numSteps;
                    if ((direction == Enums.Direction.West && (shipX + velX) >= 0) || (direction == Enums.Direction.East && (shipX + velX) <= grid.GetLength(0)))
                    {
                        shipX += velX;
                    }
                    break;
            }
        }

        public void CreateMap()
        {
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    if (y == shipY && x == shipX)
                    {
                        if(shipDirection == Enums.Direction.North.ToString())
                        {
                            grid[y, x] = '^';
                        }
                        else if(shipDirection == Enums.Direction.South.ToString())
                        {
                            grid[y, x] = 'v';
                        }
                        else if(shipDirection == Enums.Direction.West.ToString())
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
                        grid[y, x] = '-';
                    }
                }
            }
        }

        public void DrawMap()
        {
            Console.WriteLine("Map");
            Console.Write("+");
            Console.Write(new string('-', (grid.GetLength(0)*2) -1));
            Console.WriteLine("+");
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                Console.Write('|');
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    if(y == shipY && x == shipX)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    } 
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
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
            Console.WriteLine($"Wind Speed: {windSpeed.ToString("#.00")} | Wind Direction: {windDirection} | ShipDirection: {shipDirection}");
        }
    }
}
