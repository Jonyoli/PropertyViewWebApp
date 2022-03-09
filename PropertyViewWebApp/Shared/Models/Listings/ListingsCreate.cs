using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PropertyViewWebApp.Shared.Models.Amenities;

namespace PropertyViewWebApp.Shared.Models.Listings
{
    public class ListingsCreate
    {
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

        public int typeId { get; set; }

        public AmenitiesGetAll amenities { get; set; }

    }
}
