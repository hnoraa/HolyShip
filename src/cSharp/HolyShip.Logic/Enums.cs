using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic
{
    public class Enums
    {
        public enum ShipClass
        {
            Junk,
            Clipper,
            Barque,
            Frigate,
            Galleon
        }

        public enum Direction
        {
            North,
            South,
            East,
            West
        }

        public enum Scene
        {
            Title,
            MainMenu,
            PauseMenu,
            SaveMenu,
            Map,
            NewGame,
            LoadGame,
            GameOver,
            Quit
        }

        public enum Action
        {
            NewGame,
            LoadGame,
            GoToMap,
            Pause,
            MainMenu,
            SaveInitialized,
            SaveCompleted,
            Died,
            BackToGame,
            BackToTitle,
            Quit
        }
    }
}
