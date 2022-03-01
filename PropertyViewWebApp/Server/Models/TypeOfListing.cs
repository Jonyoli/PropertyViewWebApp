using System;
using System.ComponentModel.DataAnnotations;

namespace PropertyViewWebApp.Server.Models
{
    public class TypeOfListing
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
