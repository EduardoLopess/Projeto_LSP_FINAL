namespace Domain.ViewModels.ServicesViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string SenhaHash { get; set; }

        public UserViewModel UserViewModels { get; set; }
    }
}