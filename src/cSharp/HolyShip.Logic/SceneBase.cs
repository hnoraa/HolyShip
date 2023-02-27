using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic
{
    public class SceneBase
    {
        public Enums.Scene sceneId { get; set; }

        public string? currentCommand { get; set; }

        public SceneBase previousScene { get; set; }

        public SceneBase nextScene { get; set; }
        
        public SceneBase() { }

        public void Events() => currentCommand = Console.ReadLine().ToLowerInvariant();

        public void Updates() { }

        public void Rendering() { }

        public void OnEnter() { }

        public void OnExit() { }

        //public void ChangeScene(SceneBase nextScene) => this.nextScene = nextScene;
    }
}
