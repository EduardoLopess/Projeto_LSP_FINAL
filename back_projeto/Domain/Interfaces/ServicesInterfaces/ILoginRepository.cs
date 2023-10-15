using Domain.Enums;

namespace Domain.Interfaces.ServicesInterfaces
{
    public interface ILoginRepository
    {
        PerfilAcesso Authenticate(string email, string password);
    }
}