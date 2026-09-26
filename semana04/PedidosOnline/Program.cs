using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("742 Evergreen Terrace", "Springfield", "OR", "USA");
        Customer customer1 = new Customer("Homer Simpson", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Wireless Mouse", "WM-101", 25.50, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "KB-202", 89.99, 1));
        order1.AddProduct(new Product("USB-C Hub", "UH-303", 34.00, 1));

        Address address2 = new Address("Avenida Paulista, 1000", "São Paulo", "SP", "Brazil");
        Customer customer2 = new Customer("Carlos Silva", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Noise Cancelling Headphones", "HD-404", 199.90, 1));
        order2.AddProduct(new Product("Laptop Stand", "LS-505", 45.00, 2));
        order2.AddProduct(new Product("HDMI Cable 2m", "CB-606", 12.50, 3));

        DisplayOrder(order1, 1);
        DisplayOrder(order2, 2);
    }

    static void DisplayOrder(Order order, int orderNumber)
    {
        Console.WriteLine("==================================================");
        Console.WriteLine($"Order #{orderNumber}");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order.CalculateTotalCost():F2}");
        Console.WriteLine("==================================================");
        Console.WriteLine();
    }
}