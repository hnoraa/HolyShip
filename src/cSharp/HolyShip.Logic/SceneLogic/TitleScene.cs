using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic.SceneLogic
{
    public class TitleScene : SceneBase
    {
        // ASCII titles use: http://www.network-science.de/ascii/ Font: Chunky
        private readonly string _title = @"
 _______         __          _______ __     __         __ 
|   |   |.-----.|  |.--.--. |     __|  |--.|__|.-----.|  |
|       ||  _  ||  ||  |  | |__     |     ||  ||  _  ||__|
|___|___||_____||__||___  | |_______|__|__||__||   __||__|
                    |_____|                    |__|       
";
        private readonly string _options = @"
What do you want to do?
    1. New Game
    2. Load Game
    Q  Quit
";

        public TitleScene(SceneManager manager) : base(manager)
        {
            sceneId = Enums.Scene.Title;
        }

        public override string? Events(string? command)
        {
            base.Events(command);

            if(!string.IsNullOrEmpty(currentCommand))
            {
                switch(currentCommand)
                {
                    case "1":
                        manager.ChangeScene(Enums.Scene.NewGame);
                        break;
                    case "2":
                        manager.ChangeScene(Enums.Scene.LoadGame);
                        break;
                    case "q":
                        manager.ChangeScene(Enums.Scene.Quit);
                        break;
                }
            }

            return currentCommand;
        }

        public override void Updates()
        {
            base.Updates();
        }

        public override void Rendering()
        {
            base.Rendering();

            Console.WriteLine(_title);
            Console.WriteLine(_options);
        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}
