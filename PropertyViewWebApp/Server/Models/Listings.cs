using System;
using System.ComponentModel.DataAnnotations;

namespace PropertyViewWebApp.Server.Models
{
    public class Listings
    {
        [Key]
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

        public int AmenitiesId { get; set; }
        public virtual Amenitites Amenitites { get; set; }

        public int TypeOfListingId { get; set; }
        public virtual TypeOfListing TypeOfListing { get; set; }

    }
}
