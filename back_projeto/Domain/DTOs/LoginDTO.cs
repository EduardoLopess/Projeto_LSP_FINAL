namespace Domain.DTOs
{
    public class LoginDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }

        //public UsuarioDTO UsuarioDTO { get; set; }
        public int UsuarioId { get; set; }

        //public Instituto Instituto { get; set; }
        public int InstitutoId { get; set; }
    }
}