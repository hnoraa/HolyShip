using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic.SceneLogic
{
    public class NewGameScene : SceneBase
    {
        private string _name;
        private Enums.ShipClass _class;
        private bool _enteringInfo;

        public NewGameScene(SceneManager manager) : base(manager)
        {
            sceneId = Enums.Scene.NewGame;
            _enteringInfo = true;
        }

        public override string? Events(string? command)
        {
            if(!_enteringInfo)
            {
                base.Events(command);
                manager.ChangeScene(Enums.Scene.Map);
            }

            return base.currentCommand;
        }

        public override void Updates()
        {

        }

        public override void Rendering()
        {
            Console.WriteLine("Welcome to Holy Ship! the ship RPG. Please enter your name");
            _name = Console.ReadLine();

            Console.WriteLine($"Hello {_name}!\nPlease select your ship class...");
            foreach (Enums.ShipClass ship in Enum.GetValues(typeof(Enums.ShipClass)))
            {
                Console.WriteLine(ship);
            }

            string choice = Console.ReadKey().ToString();
            Console.WriteLine(choice);

            _enteringInfo = false;
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
