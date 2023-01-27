using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic
{
    public class Ship
    {
        public string name { get; set; }

        public string description { get; set; }

        public int numSails { get; set; }

        public int hitPoints { get; set; }

        public float strength { get; set; }

        public float defense { get; set; }

        public float speed { get; set; }

        public int numMovesUsed { get; set; }

        public int maxMoves { get; set; }

        public int currentTurn { get; set; }

        public int numTurnsToRestore { get; set; }

        public Ship() { }

        public void Rest(int turn)
        {
            if(turn == numTurnsToRestore)
            {
                numMovesUsed = 0;
            } 
            else
            {
                currentTurn++;
            }
        }

        public void Move() { }

        public void Save() { }
    }
}
