using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyViewWebApp.Shared.Models.Listings;

namespace PropertyViewWebApp.Server.Services.ListingsServices
{
    public interface IListingsService
    {
        //Create Listings
        Task<bool> CreateListingsAsync(ListingsCreate model);

        //Get all Listings
        Task<IEnumerable<ListingsGetAll>> GetAllListingsAsync();

        //Get Listings details
        Task<ListingsDetail> GetListingsDetailAsync(int listingsId);

        //Update Listings
        Task<bool> UpdateListingsAsync(ListingsUpdate model);

        //Delete Listings
        Task<bool> DeleteListingsAsync(int listingsId);

        //Many to Many with Amenities
        Task<bool> AddListingstoAmenitiesAsync(int listingsId, AddListingsToAmenities request);
    }
}
