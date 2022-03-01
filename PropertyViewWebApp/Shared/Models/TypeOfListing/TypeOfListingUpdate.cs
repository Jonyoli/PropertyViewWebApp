using System;
using System.ComponentModel.DataAnnotations;

namespace PropertyViewWebApp.Shared.Models.TypeOfListing
{
    public class TypeOfListingUpdate
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
