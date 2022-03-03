using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyViewWebApp.Shared.Models.TypeOfListing;

namespace PropertyViewWebApp.Server.Services.TypeOfListingServices
{
    public interface ITypeOfListingService
    {
        //TypeOfListing Creation
        Task<bool> CreateTypeAsync(TypeOfListingCreate model);

        //TypeOfListing Get all
        Task<IEnumerable<TypeOfListingGetAll>> GetAllTypeAsync();

        //Update Type
        Task<bool> UpdateTypeAsnc(TypeOfListingUpdate request);

        //Delete TypeOfListing
        Task<bool> DeleteTypeAsync(int typeId);

        //One to one relationship with listings
        Task<bool> AddTypeToListings(int typeId, int listingsId);
    }
}
