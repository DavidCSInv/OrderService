using OrderService.Base;

namespace OrderService.Models;

public class Product(string name, string description, decimal amount, decimal weight, decimal salePrice, decimal costPrice) : BaseModel
{
    public string Name { get; private set; } = name;
    public string Description { get; private set; } = description;
    public decimal Amount { get; private set; } = amount;
    public decimal Weight { get; private set; } = weight;
    public decimal SalePrice { get; private set; } = salePrice;
    public decimal CostPrice { get; private set; } = costPrice;
    public Category Category { get; private set; }
}
