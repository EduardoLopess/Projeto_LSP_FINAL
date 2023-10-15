namespace Domain.Entities
{
    public class Login
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }

        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public Instituto Instituto { get; set; }
        public int InstitutoId { get; set; }
    }
}