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
        private readonly string _filePath = "..\\..\\..\\menu.json";


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
                Environment.Exit(1);
                return [];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
                return [];
            }


        }

        public void DisplayMenu(List<MenuItem> menu)
        {
            Console.WriteLine("Étlap");
            Console.WriteLine("-----");
            foreach (var item in menu)
            {
                Console.WriteLine($"{item.Name} - {item.Price}");
            }
        }


    }
}
