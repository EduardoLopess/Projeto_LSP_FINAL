namespace Domain.DTOs
{
    public class VoluntariadoDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public IList<string> Beneficios { get; set; }
        public IList<string> Responsabilidade { get; set; }
       

        public IList<UsuarioDTO> UsuariosInscritosDTO { get; set; }
        //public InstitutoDTO InstitutoDTO { get; set; }
        public int InstitutoId { get; set; }
    }
}