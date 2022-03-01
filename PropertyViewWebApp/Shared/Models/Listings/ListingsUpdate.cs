using System;
using System.ComponentModel.DataAnnotations;

namespace PropertyViewWebApp.Shared.Models.Listings
{
    public class ListingsUpdate
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int NumberOfBeds { get; set; }

        [Required]
        public int NumberOfBaths { get; set; }

        [Required]
        public double Squarefeet { get; set; }
    }
}
