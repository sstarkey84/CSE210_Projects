using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("1344 Gold Star St", "Sacramento", "CA", "USA");
        Customer customer1 = new Customer("Jim Robinson", address1);
        
        Product product1 = new Product("Fishing pole", "F201", 90.00, 1);
        Product product2 = new Product("Head lamp", "H442", 73.55, 2);

        List<Product> products1 = new List<Product>();
        products1.Add(product1);
        products1.Add(product2);

        Order order1 = new Order(customer1, products1);

        Address address2 = new Address("1535 Buena Vista", "Mexico", "MX", "Mexico");
        Customer customer2 = new Customer("John May", address2);

        Product product3 = new Product("Hunting pack", "P504", 324.85, 1);
        Product product4 = new Product("Axe", "A334", 45.00, 4);

        List<Product> products2 = new List<Product>();
        products2.Add(product3);
        products2.Add(product4);

        Order order2 = new Order(customer2, products2);

        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Order 1 Total Cost: $" + order1.GetTotalCost().ToString("F2"));
        Console.WriteLine();
        Console.WriteLine("Order 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Order 2 Total Cost: $" + order2.GetTotalCost().ToString("F2"));
    }
}