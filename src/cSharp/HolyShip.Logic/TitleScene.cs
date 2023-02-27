using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic
{
    public class TitleScene : SceneBase
    {
        private readonly string _title = @"
 _______         __          _______ __     __        
|   |   |.-----.|  |.--.--. |     __|  |--.|__|.-----.
|       ||  _  ||  ||  |  | |__     |     ||  ||  _  |
|___|___||_____||__||___  | |_______|__|__||__||   __|
                    |_____|                    |__|   
";
        private readonly string _options = @"
What do you want to do?
    1. New Game
    2. Load Game
    3. Quit
";

        public TitleScene() => sceneId = Enums.Scene.Title;

        public void Events() 
        {
            
        }

        public void Updates()
        {

        }

        public void Rendering()
        {
            Console.WriteLine(_title);
            Console.WriteLine(_options);
        }
    }
}
