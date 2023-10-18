using Domain.Enums;

namespace Domain.DTOs
{
    public class InstituteDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public AddressDTO AddressDTOs { get; set; }
        public ProfileAcess ProfileAcess { get; set; }
        public IList<VolunteeringDTO> VolunteeringDTOs { get; set; }
        public IList<DonationMaterialDTO> DonationMaterialDTOs { get; set; }
    }
}