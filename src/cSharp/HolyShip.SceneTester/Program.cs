using HolyShip.Logic;

bool running = true;



while(running)
{
    if (Console.ReadKey().ToString().ToLowerInvariant().Equals("q"))
    {
        running = false;
    }

    // show scene
}

Console.WriteLine("End of simulation...");