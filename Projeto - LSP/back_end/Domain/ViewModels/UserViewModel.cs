using Domain.Enums;

namespace Domain.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ProfileAcess ProfileAcess { get; set; }
        public IList<AdressViewModel> AdressViewModels { get; set; }

    }
}