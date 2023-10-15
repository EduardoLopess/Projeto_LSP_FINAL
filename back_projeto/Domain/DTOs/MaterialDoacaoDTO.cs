using Domain.Entities;
using Domain.Enums;

namespace Domain.DTOs
{
    public class MaterialDoacaoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoMaterial Tipo { get; set; }
        public int PontoDoacaoId { get; set; }
        public int InstitutoId { get; set; }
    }
}