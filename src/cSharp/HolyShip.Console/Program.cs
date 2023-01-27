// intro
string title = @"
 _______         __          _______ __     __        
|   |   |.-----.|  |.--.--. |     __|  |--.|__|.-----.
|       ||  _  ||  ||  |  | |__     |     ||  ||  _  |
|___|___||_____||__||___  | |_______|__|__||__||   __|
                    |_____|                    |__|   
";
char[,] map = new char[20,20];
bool running = true;
bool mapRunning = false;

Console.Clear();
Console.WriteLine(title);
Console.WriteLine("Press S to start");
Console.WriteLine("Press Q to quit");

if(Console.ReadKey().Key != ConsoleKey.S)
{
    running = false;
}

// will load from text file
for (int x = 0; x < map.GetLength(0); x++)
{
    for (int y = 0; y < map.GetLength(1); y++)
    {
        map[x,y] = '-';
    }
}

while (running)
{
    // get the basic menu input
    Console.Clear();
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("1. Explore");
    Console.WriteLine("2. Status Menu");
    Console.WriteLine("3. Rest");
    Console.WriteLine("4. Save");
    Console.WriteLine("Press Q to quit");

    switch (Console.ReadKey().Key)
    {
        case ConsoleKey.D1:
            // create a map and cursor
            mapRunning = true;

            while(mapRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the map!");
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    for (int y = 0; y < map.GetLength(1); y++)
                    {
                        Console.Write(map[x, y] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Move");
                Console.WriteLine("2. Dock");
                Console.WriteLine("3. Main Menu");
                Console.WriteLine("Press Q to quit");

                switch(Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.D3:
                        mapRunning = false;
                        break;
                    case ConsoleKey.Q:
                        // quit
                        mapRunning = false;
                        running = false;
                        break;
                }
            }
            break;
        case ConsoleKey.D2:
            // view status
            break;
        case ConsoleKey.D3:
            // rest
            break;
        case ConsoleKey.D4:
            // save game
            break;
        case ConsoleKey.Q:
            running = false;
            break;
    }
}

Console.Clear();
Console.WriteLine("Goodbye...");