using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WHQ7HJ
{
    internal class MenuService
    {
        private readonly string _filePath = "menu.json";


        public List<MenuItem> LoadMenu()
        {
            try
            {
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<MenuItem>>(json) ?? new List<MenuItem>();
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<MenuItem>();
            }

            
        }

    }
}
