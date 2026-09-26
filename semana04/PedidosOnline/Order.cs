using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double total = 0.0;
        foreach (Product product in _products)
        {
            total += product.CalculateTotalCost();
        }

        double shippingCost = _customer.IsInUSA() ? 5.0 : 35.0;
        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label:");
        foreach (Product product in _products)
        {
            sb.AppendLine($"  - {product.GetName()} (ID: {product.GetProductId()})");
        }
        return sb.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n  {_customer.GetName()}\n  {_customer.GetAddress().GetFormattedAddress().Replace("\n", "\n  ")}";
    }
}
