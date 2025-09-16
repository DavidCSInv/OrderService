using OrderService.Base;

namespace OrderService.Models;
public class Customer(string name, string surname, string pronouns, short age, DateTime birthday, string adress, string email, string password,
    string phone, string phoneNumber, DateTime registrationDate) : BaseModel
{
    public string Name { get; private set; } = name;
    public string Surname { get; private set; } = surname;
    public string Pronouns { get; private set; } = pronouns;
    public short Age { get; private set; } = age;
    public DateTime Birthday { get; private set; } = birthday;
    public string Adress { get; private set; } = adress;
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
    public string Phone { get; private set; } = phone;
    public string PhoneNumber { get; private set; } = phoneNumber;
    public DateTime RegistrationDate { get; private set; } = registrationDate;
    public DateTime RegistrationUpdateDate { get; private set; }
    public virtual ImageModel? UserProfilePicture { get; private set; }
    public virtual ICollection<Order>? Orders { get; private set; }

    public void Update(string name, string surname, string pronouns, short age, DateTime birthday, string adress, string email, string password,
        string phone, string phoneNumber, DateTime registrationUpdate, ImageModel? userProfilePicture)
    {
        Name = name;
        Surname = surname;
        Pronouns = pronouns;
        Age = age;
        Birthday = birthday;
        Adress = adress;
        Email = email;
        Password = password;
        Phone = phone;
        PhoneNumber = phoneNumber;
        UserProfilePicture = userProfilePicture;
        RegistrationUpdateDate = registrationUpdate;
    }

}
