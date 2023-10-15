namespace Domain.ViewModels.ServicesViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string SenhaHash { get; set; }

        public UsuarioViewModel UsuarioViewModel { get; set; }
        public InstitutoViewModel InstitutoViewModel { get; set; }
    }
}