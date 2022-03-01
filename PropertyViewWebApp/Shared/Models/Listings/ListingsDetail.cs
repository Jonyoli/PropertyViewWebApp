using System;
namespace PropertyViewWebApp.Shared.Models.Listings
{
    public class ListingsDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int NumberOfBeds { get; set; }
        public int NumberOfBaths { get; set; }
        public double Squarefeet { get; set; }
    }
}
