using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PropertyViewWebApp.Server.Models
{
    public class Amenities
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Listings> Listings { get; set; }
    }
}
