using System;
using System.ComponentModel.DataAnnotations;

namespace PropertyViewWebApp.Shared.Models.Amenities
{
    public class AmenitiesCreate
    {
       [Required]
        public string Name { get; set; }
    }
}
