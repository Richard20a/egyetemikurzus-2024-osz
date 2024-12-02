using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WHQ7HJ
{
    internal class OrderService
    {

        private readonly string _filePath = "orders.json";


        public List<MenuItem> LoadOrders()
        {
            try
            {
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<MenuItem>>(json) ?? new List<MenuItem>();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<MenuItem>();
            }


        }

    }
}
