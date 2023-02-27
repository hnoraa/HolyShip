using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic.SceneLogic
{
    internal class QuitScene : SceneBase
    {
        private readonly string _text = "Goodbye...";

        public QuitScene(SceneManager manager) : base(manager)
        {
            sceneId = Enums.Scene.Quit;
        }

        public override string? Events(string? command)
        {
            base.Events(command);
            currentCommand = "quit";
            return base.currentCommand;
        }

        public override void Updates()
        {
            base.Updates();
        }

        public override void Rendering()
        {
            base.Rendering();
            Console.WriteLine(_text);
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