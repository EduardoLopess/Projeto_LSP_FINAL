namespace Domain.ViewModels
{
    public class UsuarioViewModel
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }

        public List<EnderecoViewModel> EnderecoViewModel { get; set; }
        public IList<VoluntariadoViewModel> VoluntariadosInscritosViewModel { get; set; }
    }
}