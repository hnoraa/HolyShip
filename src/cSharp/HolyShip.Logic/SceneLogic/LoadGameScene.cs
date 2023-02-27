using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic.SceneLogic
{
    internal class LoadGameScene : SceneBase
    {
        private readonly string _options = @"
Which Game do you want to load?
    Save 1
    Save 2
    Save 3
(Q) Quit
";

        public LoadGameScene(SceneManager manager) : base(manager)
        {
            this.sceneId = Enums.Scene.LoadGame;
        }

        public override string? Events(string? command)
        {
            base.Events(command);

            if (!string.IsNullOrEmpty(base.currentCommand))
            {
                switch(base.currentCommand)
                {
                    case "1":
                    case "2":
                    case "3":
                        // load the game
                        base.manager.ChangeScene(Enums.Scene.Map);
                        break;
                    case "q":
                        base.manager.ChangeScene(Enums.Scene.Quit);
                        break;
                }
            }

            return base.currentCommand;
        }

        public override void Updates()
        {

        }

        public override void Rendering()
        {
            Console.WriteLine("Map");
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