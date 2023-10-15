using Domain.Enums;

namespace Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }

        public IList<Endereco> Enderecos { get; set; }
        public IList<Voluntariado> VoluntariadosInscritos { get; set; } // Lista de voluntariados em que o usuário está inscrito
        public Login Login { get; set; }
        public PerfilAcesso Perfil { get; set; } //Enum
    }
}