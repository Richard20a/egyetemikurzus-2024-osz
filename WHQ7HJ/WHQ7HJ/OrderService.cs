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

        private readonly string _filePath = "..\\..\\..\\orders.json";


        public List<Order> LoadOrders()
        {
            try
            {
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Order>>(json) ?? new List<Order>();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Order>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Order>();
            }

        }

        public Order CreateOrder(List<MenuItem> menu)
        {
            Console.Write("Add meg a neved: ");
            string customerName = Console.ReadLine() ?? "Ismeretlen";

            var orderItems = new List<MenuItem>();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Add meg a választott étel nevét (vagy 'OK' a befejezéshez): ");
                string input = Console.ReadLine();

                if (input?.ToLower() == "ok")
                {
                    break;
                }

                var menuItem = menu.FirstOrDefault(item => item.Name.Equals(input, StringComparison.OrdinalIgnoreCase));

                if (menuItem != null)
                {
                    orderItems.Add(menuItem);
                    Console.WriteLine($"{menuItem.Name} hozzáadva a rendeléshez.");
                }
                else
                {
                    Console.WriteLine("Nincs ilyen étel az étlapon!");
                }

                Console.WriteLine("Nyomj egy gombot a folytatáshoz...");
                Console.ReadKey();
            }

            return new Order(customerName, orderItems);
        }

        public void SaveOrders(List<Order> orders)
        {
            string json = JsonSerializer.Serialize(orders, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }


    }
}
