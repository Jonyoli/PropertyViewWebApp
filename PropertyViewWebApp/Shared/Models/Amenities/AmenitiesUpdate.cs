using System;
using System.ComponentModel.DataAnnotations;

namespace PropertyViewWebApp.Shared.Models.Amenities
{
    public class AmenitiesUpdate
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
