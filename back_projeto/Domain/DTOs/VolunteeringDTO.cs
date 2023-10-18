namespace Domain.DTOs
{
    public class VolunteeringDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<BenefitDTO> BenefitDTOs { get; set; }
        public IList<ResposibilityDTO> ResposibilityDTOs { get; set; }

        public InstituteDTO InstituteDTOs { get; set; }
    }
}