using Domain.Enums;

namespace Domain.ViewModels
{
    public class InstituteViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public AdressViewModel AdressViewModel { get; set; }
        public ProfileAcess ProfileAcess { get; set; }
        public IList<VolunteeringViewModel> VolunteeringViewModels { get; set; }
        public IList<DonationMaterialViewModel> DonationMaterialViewModels { get; set; }
        
    }
}