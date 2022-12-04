using System;
using SistemaPedidos.Entities;
using System.Globalization;
using SistemaPedidos.Entities.Enums;
namespace SistemaPedidos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();
            Console.Write("E-mail: ");
            string clientEmail = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime clientBirth = DateTime.Parse(Console.ReadLine());

            Client cl = new Client(clientName, clientEmail, clientBirth);
            int clientStatusNumber;
            OrderStatus os = new OrderStatus();

            do
            {   
                Console.WriteLine();
                Console.WriteLine("Enter order data: ");
                Console.WriteLine("Status: \n1-Pending_Payment\n2-Processing\n3-Shipped\n4-Delivered");
                clientStatusNumber = int.Parse(Console.ReadLine());
                
                switch (clientStatusNumber)
                {
                    case 1:
                        os = (OrderStatus)Enum.Parse(typeof(OrderStatus), "Pending_Payment");
                        break;

                    case 2:
                        os = (OrderStatus)Enum.Parse(typeof(OrderStatus), "Processing");
                        break;

                    case 3:
                        os = (OrderStatus)Enum.Parse(typeof(OrderStatus), "Shipped");
                        break;

                    case 4:
                        os = (OrderStatus)Enum.Parse(typeof(OrderStatus), "Delivered");
                        break;

                    default: Console.WriteLine("invalid option");
                        break;
                }
            } while (clientStatusNumber > 4);

            Console.Write("How many items to this order? ");
            int clientItemsQtd = int.Parse(Console.ReadLine());

            Order order = new Order(DateTime.Now, os, cl);

            for (int i = 1; i <= clientItemsQtd; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string prodName = Console.ReadLine();
                Console.Write("Product price: ");
                double prodPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int prodQtd = int.Parse(Console.ReadLine());

                Product prod = new Product(prodName, prodPrice);
                OrderItem item = new OrderItem(prodQtd, prodPrice, prod);
                order.AddItem(item);
            }

            Console.WriteLine();
            Console.WriteLine(order.ToString());
        }
    }
}
