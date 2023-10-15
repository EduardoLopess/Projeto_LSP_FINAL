using Domain.Entities;

namespace Domain.DTOs
{
    public class InstitutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }

        //public EnderecoDTO EnderecoDTO { get; set;}
        public int EnderecoId { get; set; }
        //public VoluntariadoDTO VoluntariadoDTO { get; set;}
        public int VoluntariadoId { get; set; }
        //public MaterialDoacaoDTO MaterialDoacaoDTO { get; set; }
        public int MateriasDoacaoId { get; set; } 
    }
}