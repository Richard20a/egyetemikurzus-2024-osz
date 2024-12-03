using WHQ7HJ;

var menuService = new MenuService();
var orderService = new OrderService();

var menu = menuService.LoadMenu();
var orders = orderService.LoadOrders();

while (true)
{
    Console.Clear();
    Console.WriteLine("Éttermi Rendeléskezelő");
    Console.WriteLine("----------------------");
    Console.WriteLine("1. Étlap megtekintése");
    Console.WriteLine("2. Rendelés leadása");
    Console.WriteLine("3. Rendelések megtekintése");
    Console.WriteLine("4. Rendelések összesítése");
    Console.WriteLine("5. Kilépés");

    Console.Write("Válassz egy menüpontot: ");
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
            Console.WriteLine("Rendelés rögzítve!");
            break;
        case "3":
           
            break;
        case "4":
            
            break;
        case "5":
            return;
        default:
            Console.WriteLine("Érvénytelen választás!");
            break;
    }

    Console.WriteLine("Nyomj egy gombot a folytatáshoz...");
    Console.ReadKey();
}