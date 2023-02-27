using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic.Entities
{
    public class Ship
    {
        public int posX { get; set; }

        public int posY { get; set; }

        public int maxNumTurns { get; private set; }

        public int numTurnsTaken { get; private set; }

        public int maxNumRestTurns { get; private set; }

        public int numRestTurnsTaken { get; private set; }

        public Enums.Direction direction { get; set; }

        private int _level;

        private int _hitPoints;

        private bool _isResting;

        public Ship(int posX, int posY, Enums.Direction direction)
        {
            this.posX = posX;
            this.posY = posY;
            this.direction = direction;

            maxNumTurns = 5;
            maxNumRestTurns = 5;

            numRestTurnsTaken = 0;
            numTurnsTaken = 0;

            _level = 0;
            _hitPoints = 100;
            _isResting = false;
        }

        public bool IsResting()
        {
            return _isResting;
        }

        public int RestTurnsLeft()
        {
            return maxNumRestTurns - numRestTurnsTaken;
        }

        public int TurnsLeft()
        {
            return maxNumTurns - numTurnsTaken;
        }

        public void TakeRestTurn()
        {
            if (numRestTurnsTaken == maxNumRestTurns)
            {
                _isResting = false;
                numRestTurnsTaken = 0;
            }
            else
            {
                numRestTurnsTaken++;
            }
        }

        public void Move(Enums.Direction direction, int numSteps, int gridHeight, int gridWidth)
        {
            this.direction = direction;

            switch (direction)
            {
                case Enums.Direction.North:
                case Enums.Direction.South:
                    int velY = direction == Enums.Direction.North ? -numSteps : numSteps;
                    if (direction == Enums.Direction.North && posY + velY >= 0 || direction == Enums.Direction.South && posY + velY <= gridHeight)   //grid.GetLength(1)
                    {
                        posY += velY;
                    }
                    break;
                case Enums.Direction.West:
                case Enums.Direction.East:
                    int velX = direction == Enums.Direction.West ? -numSteps : numSteps;
                    if (direction == Enums.Direction.West && posX + velX >= 0 || direction == Enums.Direction.East && posX + velX <= gridWidth)   //grid.GetLength(0)
                    {
                        posX += velX;
                    }
                    break;
            }

            numTurnsTaken += numSteps;

            if (numTurnsTaken >= maxNumTurns)
            {
                numTurnsTaken = 0;
                _isResting = true;
            }
            else
            {
                _isResting = false;
            }
        }
    }
}
