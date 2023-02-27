using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic.SceneLogic
{
    public abstract class SceneBase
    {
        public SceneManager manager;

        public Enums.Scene sceneId { get; set; }

        public string? currentCommand { get; set; }

        public SceneBase(SceneManager manager)
        {
            this.manager = manager;    
        }

        public virtual string? Events(string? command)
        {
            currentCommand = command;

            if(currentCommand != null)
            {
                currentCommand = currentCommand.ToLowerInvariant();
            }

            return currentCommand;
        }

        public virtual void Updates() { }

        public virtual void Rendering() { }

        public virtual void OnEnter() { }

        public virtual void OnExit() { }
    }
}
