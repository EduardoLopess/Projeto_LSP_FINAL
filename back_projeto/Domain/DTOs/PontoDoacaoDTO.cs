using Domain.Enums;

namespace Domain.DTOs
{
    public class PontoDoacaoDTO
    {
        public int Id { get; set; }
        public string NomeLocal { get; set; }
        public TipoMaterial MateriasAceito { get; set; }

        //public EnderecoDTO EnderecoDTO { get; set; }
        public int EnderecoId { get; set; }
        //public InstitutoDTO InstitutoDTO { get; set; }
        public int IntitutoId { get; set; } 
    }
}