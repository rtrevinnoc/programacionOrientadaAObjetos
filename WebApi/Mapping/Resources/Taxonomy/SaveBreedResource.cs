using System.ComponentModel.DataAnnotations;

namespace WebApi.Mapping.Resources.Taxonomy
{
    public class SaveBreedResource
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        [Required]
        public Guid SpecieId { get; set; }
    }
}