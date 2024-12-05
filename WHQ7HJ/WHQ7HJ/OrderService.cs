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
            Console.Write("Enter your name: ");
            string customerName = Console.ReadLine();
            if (string.IsNullOrEmpty(customerName)){ customerName = "Anonymous customer"; }
            
            string orderdate = DateTime.Today.ToString("dd/MM/yyyy");

            var orderItems = new List<MenuItem>();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Enter the name of the chosen dish (or 'OK' to finish): ");
                string input = Console.ReadLine();

                if (input?.ToLower() == "ok")
                {
                    break;
                }

                var menuItem = menu.FirstOrDefault(item => item.Name.Equals(input, StringComparison.OrdinalIgnoreCase));

                if (menuItem != null)
                {
                    orderItems.Add(menuItem);
                    Console.WriteLine($"{menuItem.Name} added to the order.");
                }
                else
                {
                    Console.WriteLine("There is no such dish on the menu!");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            return new Order(customerName, orderdate, orderItems);
        }

        public void SaveOrders(List<Order> orders)
        {
            try
            {
                string json = JsonSerializer.Serialize(orders, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
        }

        public void DisplayOrders(List<Order> orders)
        {
            Console.WriteLine("");
            Console.WriteLine("Orders");
            Console.WriteLine("-----");
            if(orders.Count == 0)
            {
                Console.WriteLine("No order has been received yet.");
            }
            else
            {
                foreach (var order in orders)
                {
                    Console.WriteLine($"Name: {order.CustomerName}, Date: {order.OrderDate}, Order: {string.Join(", ", order.MenuItems.Select(item => item.Name))}");
                }
            }
        }

        public void DisplayPopularItems(List<Order> orders)
        {
           if(orders.Count == 0)
            {
                Console.WriteLine("No order has been received yet.");
            }
            else
            {
                var popularItems = orders.SelectMany(order => order.MenuItems)
                                     .GroupBy(item => item.Name)
                                     .OrderByDescending(group => group.Count())
                                     .Select(group => new { Item = group.Key, Count = group.Count() });

                Console.WriteLine("Popular dishes");
                Console.WriteLine("--------------");
                foreach (var item in popularItems)
                {
                    Console.WriteLine($"{item.Item}: {item.Count} orders");
                }
            }
        }

        public void CalculateTotal(List<Order> orders)
        {
            Console.WriteLine($"Total revenue: {orders.Sum(order => order.MenuItems.Sum(item => item.Price))} Ft.");
        }


    }
}
