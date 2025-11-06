using System.ComponentModel.DataAnnotations;

namespace WebApi.Mapping.Resources.Locations
{
    public class SaveRanchResource
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(250)]
        public required string Location { get; set; }
    }
}