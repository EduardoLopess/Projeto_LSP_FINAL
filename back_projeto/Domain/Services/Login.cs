using Domain.Entities;

namespace Domain.Services
{
    public class Login
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
        

    }
}