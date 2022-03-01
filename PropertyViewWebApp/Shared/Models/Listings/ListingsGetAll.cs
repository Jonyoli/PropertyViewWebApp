using System;
namespace PropertyViewWebApp.Shared.Models.Listings
{
    public class ListingsGetAll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int NumberOfBeds { get; set; }
        public int NumberOfBaths { get; set; }

    }
}
