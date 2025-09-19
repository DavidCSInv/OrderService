namespace OrderService.Base.Models
{
    public class BaseViewModel
    {
        public long Id { get; private set; }

        public BaseViewModel()
        {
            Id = new long();
        }
    }

}
