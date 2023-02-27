using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic.SceneLogic
{
    public class SceneManager
    {
        private List<SceneBase> _scenes = new List<SceneBase>();
        private SceneBase _currentScene;
        private SceneBase _lastScene;
        private Enums.Action _currentAction;
        private string? _currentCommand;

        public SceneManager()
        {
            _scenes.Add(new TitleScene(this));
            _scenes.Add(new LoadGameScene(this));
            _scenes.Add(new NewGameScene(this));
            _scenes.Add(new MapScene(this));
            _scenes.Add(new SaveMenuScene(this));
            _scenes.Add(new PauseMenuScene(this));
            _scenes.Add(new MainMenuScene(this));
            _scenes.Add(new GameOverScene(this));
            _scenes.Add(new QuitScene(this));

            _currentScene = _scenes.First(x => x.sceneId == Enums.Scene.Title);
            _lastScene = _currentScene;
        }

        public string? Events(string? command)
        {
            _currentCommand = command;
            return _currentScene.Events(_currentCommand);
        }

        public void Updates()
        {
            _currentScene.Updates();
        }

        public void Rendering()
        {
            _currentScene.Rendering();
        }

        public void ChangeScene(Enums.Scene nextScene)
        {
            _lastScene = _currentScene;
            _currentScene = _scenes.First(x => x.sceneId == nextScene);
        }
    }
}
