using Domain.Enums;

namespace Domain.ViewModels
{
    public class PontoDoacaoViewModel
    {
        public string NomeLocal { get; set; }
        public TipoMaterial MateriasAceito { get; set; }//Enum

        public EnderecoViewModel EnderecoViewModel { get; set; }
        public InstitutoViewModel InstitutoViewModel { get; set; }
    }
}