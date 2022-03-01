using System;
using System.ComponentModel.DataAnnotations;

namespace PropertyViewWebApp.Server.Models
{
    public class Amenitites
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int ListingsId { get; set; }
        public virtual Listings Listings { get; set; }
    }
}
