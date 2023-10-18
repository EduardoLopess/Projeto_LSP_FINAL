namespace Domain.DTOs
{
    public class ResposibilityDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public VolunteeringDTO VolunteeringDTOs { get; set; }
    }
}