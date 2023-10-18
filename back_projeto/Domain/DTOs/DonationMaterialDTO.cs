using Domain.Enums;

namespace Domain.DTOs
{
    public class DonationMaterialDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeMaterial TypeMaterial { get; set; }
        public DonationPointDTO DonationPointDTO { get; set; }
        public InstituteDTO InstituteDTO { get; set; }
    }
}