namespace Domain.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }

        public IList<EnderecoDTO> EnderecosDTO { get; set; }
        public IList<VoluntariadoDTO> VoluntariadosInscritosDTO { get; set; } 
    }
}