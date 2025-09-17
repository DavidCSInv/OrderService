using OrderService.Base.Models;

namespace OrderService.Models;
public class Order(int OrderNumber, int Amount, DateTime OrderDate, DateTime DeadLine, decimal Price, decimal Discount, string Payment, string Supplier) : BaseModel
{
    public int OrderNumber { get; private set; } = OrderNumber;
    public Customer Customer { get; private set; }
    public int Amount { get; private set; } = Amount;
    public DateTime OrderDate { get; private set; } = OrderDate;
    public DateTime DeadLine { get; private set; } = DeadLine;
    public decimal Price { get; private set; } = Price;
    public decimal Discount { get; private set; } = Discount;
    public string Payment { get; private set; } = Payment;
    public string Supplier { get; private set; } = Supplier;
}
