using Domain.Enums;

namespace Domain.Entities
{
    public class PontoDoacao
    {
        public int Id { get; set; }
        public string NomeLocal { get; set; }
        public TipoMaterial MateriasAceito { get; set; }//Enum

        public Endereco Endereco { get; set; }
        public Instituto Instituto { get; set; }
    }
}