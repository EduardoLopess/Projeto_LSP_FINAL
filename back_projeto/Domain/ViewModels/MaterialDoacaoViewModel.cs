using Domain.Enums;

namespace Domain.ViewModels
{
    public class MaterialDoacaoViewModel
    {
        public string Nome { get; set; }
        public TipoMaterial Tipo { get; set; } //Enum
        public PontoDoacaoViewModel PontoDoacaoViewModel { get; set; }
        public InstitutoViewModel InstitutoViewModel { get; set; }
    }
}