using Domain.Enums;

namespace Domain.Entities
{
    public class Institute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Address Address { get; set; }
        public ProfileAcess ProfileAcess { get; set; }
        public IList<Volunteering> Volunteerings { get; set; }
        public IList<DonationMaterial> DonationMaterials { get; set; }
 
    }
}