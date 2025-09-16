using OrderService.Base.Models;
using OrderService.Models;

namespace OrderService.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pronouns { get; set; }
        public short Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ImageModel? UserProfilePicture { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
