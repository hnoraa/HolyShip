using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic.SceneLogic
{
    public class PauseMenuScene : SceneBase
    {
        private readonly string _title = @"

 ______                             __ 
|   __ \.---.-.--.--.-----.-----.--|  |
|    __/|  _  |  |  |__ --|  -__|  _  |
|___|   |___._|_____|_____|_____|_____|
";
        private readonly string _options = @"
Press B to go back to the game...
";

        public PauseMenuScene(SceneManager manager) : base(manager)
        {
            sceneId = Enums.Scene.PauseMenu;
        }

        public override string? Events(string? command)
        {
            base.Events(command);
            if (!string.IsNullOrEmpty(currentCommand) && currentCommand.Equals("b"))
            {

            }

            return currentCommand;
        }

        public override void Updates()
        {

        }

        public override void Rendering()
        {
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
