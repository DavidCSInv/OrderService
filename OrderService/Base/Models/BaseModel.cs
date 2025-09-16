namespace OrderService.Base.Models
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {

        }

        public long Id { get; set; }
    }
}
