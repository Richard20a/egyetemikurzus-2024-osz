using WHQ7HJ;

var menuService = new MenuService();
var orderService = new OrderService();

var menu = menuService.LoadMenu();
var orders = orderService.LoadOrders();

while (true)
{
    Console.Clear();
    Console.WriteLine("1. View menu");
    Console.WriteLine("2. Place an order");
    Console.WriteLine("3. View orders");
    Console.WriteLine("4. Summary of orders");
    Console.WriteLine("5. Exit");

    Console.Write("Choose an option: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            menuService.DisplayMenu(menu);
            break;
        case "2":
            Order order = orderService.CreateOrder(menu);
            orders.Add(order);
            orderService.SaveOrders(orders);
            Console.WriteLine("Order recorded!");
            break;
        case "3":
            orderService.DisplayOrders(orders);           
            break;
        case "4":
            orderService.CalculateTotal(orders);
            orderService.DisplayPopularItems(orders);
            break;
        case "5":
            return;
        default:
            Console.WriteLine("Invalid choice!");
            break;
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}