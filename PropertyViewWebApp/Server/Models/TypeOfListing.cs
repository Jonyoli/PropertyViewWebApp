using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyViewWebApp.Server.Models
{
    public class TypeOfListing
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(Listings))]
        public int listingsId { get; set; }
        public virtual Listings Listings { get; set; }
    }
}
