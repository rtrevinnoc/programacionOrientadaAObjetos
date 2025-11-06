using System.ComponentModel.DataAnnotations;

namespace WebApi.Mapping.Resources.Locations
{
    public class AssignCorralResource
    {
        [Required]
        public Guid CorralId { get; set; }
    }
}