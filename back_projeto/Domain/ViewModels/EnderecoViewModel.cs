namespace Domain.ViewModels
{
    public class EnderecoViewModel
    {
        public string Logradouro { get; set; }
        public int NumeroCasa { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public int Cep { get; set; }
        public string Cidade { get; set; }

        public UsuarioViewModel UsuarioViewModel { get; set; }
    }
}