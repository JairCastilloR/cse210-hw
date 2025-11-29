using System;

class Program
{
    static void Main(string[] args)
    {
        // Address 1 (USA)
        Address addr1 = new Address("123 Main St", "Miami", "FL", "USA");
        Customer cust1 = new Customer("John Smith", addr1);

        // Address 2 (International)
        Address addr2 = new Address("Av. La Marina 450", "Lima", "Lima", "Peru");
        Customer cust2 = new Customer("Ana Rodriguez", addr2);

        // Order 1
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "P001", 1200m, 1));
        order1.AddProduct(new Product("Mouse", "P002", 25m, 2));

        // Order 2
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Construction Helmet", "H100", 45m, 3));
        order2.AddProduct(new Product("Safety Gloves", "G200", 18m, 4));

        // Display Orders
        Console.WriteLine("ORDER 1");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: {order1.CalculateTotalCost():C}\n");

        Console.WriteLine("ORDER 2");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: {order2.CalculateTotalCost():C}\n");
    }
}
