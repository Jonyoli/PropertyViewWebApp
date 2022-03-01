using System;
using System.ComponentModel.DataAnnotations;

namespace PropertyViewWebApp.Shared.Models.TypeOfListing
{
    public class TypeOfListingCreate
    {
        [Required]
        public string Name { get; set; }
    }
}
