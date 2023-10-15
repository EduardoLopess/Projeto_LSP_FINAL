using Domain.Enums;

namespace Domain.Entities
{
    public class MaterialDoacao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoMaterial Tipo { get; set; } //Enum
        public PontoDoacao PontoDoacao { get; set; }
        public Instituto Instituto { get; set; }
    }

}