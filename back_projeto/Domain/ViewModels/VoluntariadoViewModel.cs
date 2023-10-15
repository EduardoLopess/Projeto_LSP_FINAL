namespace Domain.ViewModels
{
    public class VoluntariadoViewModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public IList<string> Beneficios { get; set; }
        public IList<string> Responsabilidade { get; set; }

        public IList<UsuarioViewModel> UsuariosInscritosViewModel { get; set; }
        public InstitutoViewModel InstitutoViewModel { get; set; }
    }
}