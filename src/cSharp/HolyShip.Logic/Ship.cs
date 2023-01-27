using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic
{
    public class Ship
    {
        public int posX { get; set; }

        public int posY { get; set; }

        public Enums.Direction direction { get; set; }

        private int _restDuration { get; set; }

        private int _restTurnsTaken { get; set; }

        private int _maxNumTurns { get; set; }

        private int _numTurnsUsed { get; set; }

        private int _level { get; set; }

        private int _hitPoints { get; set; }

        private bool _isResting { get; set; }

        public Ship(int posX, int posY, Enums.Direction direction)
        {
            this.posX = posX;
            this.posY = posY;
            this.direction = direction;

            _maxNumTurns = 5;
            _numTurnsUsed = 0;
            _level = 0;
            _hitPoints = 100;
            _isResting = false;
            _restTurnsTaken = 0;
            _restDuration = 5;
        }

        public bool IsResting()
        {
            return _isResting;
        }

        public int TurnsLeft()
        {
            return _maxNumTurns - _numTurnsUsed;
        }

        public void TakeTurn(int numSteps)
        {
            if(_isResting)
            {
                if(_restTurnsTaken == _restTurnsTaken)
                {
                    _isResting = false;
                } 
                else
                {
                    _restTurnsTaken += numSteps;
                }
            }
            else
            {
                if (_numTurnsUsed == _maxNumTurns)
                {
                    _numTurnsUsed = 0;
                    _isResting = true;
                }
                else
                {
                    _numTurnsUsed++;
                    _isResting = false;
                }
            }
        }

        public void Move(Enums.Direction direction, int numSteps, int gridHeight, int gridWidth) {
            TakeTurn(numSteps);

            if(!_isResting)
            {
                this.direction = direction;

                switch (direction)
                {
                    case Enums.Direction.North:
                    case Enums.Direction.South:
                        int velY = direction == Enums.Direction.North ? -numSteps : numSteps;
                        if ((direction == Enums.Direction.North && (posY + velY) >= 0) || (direction == Enums.Direction.South && (posY + velY) <= gridHeight))   //grid.GetLength(1)
                        {
                            posY += velY;
                        }
                        break;
                    case Enums.Direction.West:
                    case Enums.Direction.East:
                        int velX = direction == Enums.Direction.West ? -numSteps : numSteps;
                        if ((direction == Enums.Direction.West && (posX + velX) >= 0) || (direction == Enums.Direction.East && (posX + velX) <= gridWidth))   //grid.GetLength(0)
                        {
                            posX += velX;
                        }
                        break;
                }
            }
        }

        public void LevelUp()
        {

        }
    }
}
