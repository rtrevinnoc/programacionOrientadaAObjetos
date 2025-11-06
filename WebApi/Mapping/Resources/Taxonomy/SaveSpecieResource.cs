using System.ComponentModel.DataAnnotations;

namespace WebApi.Mapping.Resources.Taxonomy
{
    public class SaveSpecieResource
    {
        [Required]
        [MaxLength(100)]
        public required string CommonName { get; set; }

        [Required]
        [MaxLength(100)]
        public required string? ScientificName { get; set; }

        public int SpecieId { get; set; }
    }
}