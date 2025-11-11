using System.ComponentModel.DataAnnotations;

namespace WebApi.Mapping.Resources.Locations
{
    public class SaveRanchResource
    {
        public Guid RanchId { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(250)]
        public required string Location { get; set; }

        [Required]
        public Guid RancherId { get; set; }
    }
}