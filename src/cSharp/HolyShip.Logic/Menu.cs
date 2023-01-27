using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyShip.Logic
{
    public class Menu
    {
        public string type { get; set; }

        public string name { get; set; }

        public List<string> options { get; set; }

        public Menu(string type, string name, List<string> options)
        {
            this.type = type;
            this.name = name;
            this.options = options;
        }

        public void DrawMenu()
        {
            Console.WriteLine(name);
            
            foreach(var option in options)
            {
                Console.WriteLine($"{options.IndexOf(option)}\t{option}");
            }
            Console.WriteLine("Press Q to quit...");
        }
    }
}
