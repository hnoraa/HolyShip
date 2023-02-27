using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic.SceneLogic
{
    public class SaveMenuScene : SceneBase
    {
        private readonly string _options = @"
What do you want to do?
    1. Save Game
    2. Back to Game
";

        public SaveMenuScene(SceneManager manager) : base(manager)
        {
            sceneId = Enums.Scene.SaveMenu;
        }

        public override string? Events(string? command)
        {
            base.Events(command);

            if (!string.IsNullOrEmpty(currentCommand))
            {

            }

            return currentCommand;
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
