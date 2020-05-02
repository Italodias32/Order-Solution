using System;
using System.Globalization;
using OrderSolution.Entities;
using OrderSolution.Entities.Enums;

namespace OrderSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order? ");
            int itemsToThisOrder = int.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);
            DateTime moment = DateTime.Now;

            Order order = new Order(moment, status, client);

            for(int i = 1; i <= itemsToThisOrder; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                name = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(name, price);
                OrderItem orderItem = new OrderItem(quantity, product);

                order.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine(order.ToString());
        }
    }
}
