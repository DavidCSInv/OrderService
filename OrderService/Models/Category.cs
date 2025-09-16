using OrderService.Base.Models;

namespace OrderService.Models;

public class Category(string categoryName, string categoryDescription, string subCategory) : BaseModel
{
    public string CategoryName { get; private set; } = categoryName;
    public string CategoryDescription { get; private set; } = categoryDescription;
    public string SubCategory { get; private set; } = subCategory;
}
