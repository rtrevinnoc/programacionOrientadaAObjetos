using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Products
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Category { get; set; }

        public Product(int id, string name, string category)
        {
            Id = id;
            Name = name;
            Category = category;
        }
    }
}
