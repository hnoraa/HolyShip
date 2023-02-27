using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic.SceneLogic
{
    internal class GameOverScene : SceneBase
    {
        private readonly string _options = @"
What do you want to do?
    1. Back To Title
    2. Quit
";

        public GameOverScene(SceneManager manager) : base(manager)
        {
            sceneId = Enums.Scene.GameOver;
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