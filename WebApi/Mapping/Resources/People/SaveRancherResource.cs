using System.ComponentModel.DataAnnotations;

namespace WebApi.Mapping.Resources.People
{
    public class SaveRancherResource
    {
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required]
        [StringLength(50)]
        public required string Username { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public required string Password { get; set; }
    }
}