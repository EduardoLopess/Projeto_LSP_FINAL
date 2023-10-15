using Domain.Services;

namespace Domain.Entities
{
    public class Voluntariado
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public IList<VoluntariadoBeneficio> Beneficios { get; set; }
        public IList<VoluntariadoResponsabilidade> Responsabilidade { get; set; }

        public IList<Usuario> UsuariosInscritos { get; set; }
        public Instituto Instituto { get; set; }
        public int InstitutoId { get; set; }
    }
}