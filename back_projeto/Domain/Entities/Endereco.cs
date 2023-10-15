namespace Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int NumeroCasa { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public int Cep { get; set; }
        public string Cidade { get; set; }
        
        //Relacionamentos
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; } //fk
        public Instituto Instituto { get; set; }
        public int InstitutoId { get; set; } // fk
        public Voluntariado Voluntariado { get; set; }
        public int VoluntariadoId { get; set; } //fk
        public PontoDoacao PontoDoacao { get; set; }
        public int PontoDoacaoId { get; set; } //fk
    }
}