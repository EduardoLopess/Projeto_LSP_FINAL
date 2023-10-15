using Domain.Enums;

namespace Domain.Entities
{
    public class Instituto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        //public string Tipo { get; set; }

        public Endereco Endereco { get; set; }
        public PerfilAcesso Perfil { get; set; } //Enum
        public IList<Voluntariado> Voluntariados { get; set; }
        public IList<MaterialDoacao> MateriasDoacao { get; set; } 
    }
}   


