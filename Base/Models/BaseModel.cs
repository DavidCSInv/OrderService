namespace OrderService.Base.Models
{
    public abstract class BaseModel
    {
        public long Id { get; private set; }

        protected BaseModel()
        {
            // Generate a unique runtime Id for validation
            Id = new long();
        }
    }
}