using Domain.Enums;

namespace Domain.ViewModels
{
    public class InstitutoViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }

        public EnderecoViewModel EnderecoViewModel { get; set; }
        public PerfilAcesso Perfil { get; set; } //Enum
        public IList<VoluntariadoViewModel> VoluntariadoViewModel { get; set; }
        public IList<MaterialDoacaoViewModel> MaterialDoacaoViewModel { get; set; } 
    }
}