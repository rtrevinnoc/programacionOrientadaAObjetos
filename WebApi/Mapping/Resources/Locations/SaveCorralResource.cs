using System.ComponentModel.DataAnnotations;

namespace WebApi.Mapping.Resources.Locations
{
    public class SaveCorralResource
    {
        //public Guid CorralId { get; set; }

        [Required]
        public Guid RanchId { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Capacity { get; set; }
    }
}