public class Order
{
    private Customer _customer;
    private List<Product> _products = new List<Product>();
    private decimal _totalCost;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal productTotal = 0;

        foreach (Product p in _products)
        {
            productTotal += p.GetTotalCost();
        }

        decimal shippingCost = _customer.LivesInUSA() ? 5 : 35;

        _totalCost = productTotal + shippingCost;
        return _totalCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing List\n";

        foreach (Product p in _products)
        {
            label += $"{p.DisplayProductInfo()}\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return $"Ship To:\n{_customer.GetCustomerInfo()}";
    }
}
