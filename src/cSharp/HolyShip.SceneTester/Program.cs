using HolyShip.Logic;
using HolyShip.Logic.SceneLogic;

bool running = true;
string? command;

SceneManager sceneManager = new SceneManager();

sceneManager.Rendering();

while(running)
{
    command = Console.ReadLine();
    
    string? result = sceneManager.Events(command);

    if (result != null)
    {
        if (result.Equals("quit"))
        {
            break;
        }
    }

    sceneManager.Updates();

    sceneManager.Rendering();
}

Console.WriteLine("End of simulation...");