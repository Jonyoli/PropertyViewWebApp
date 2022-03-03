using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyViewWebApp.Shared.Models.Amenities;

namespace PropertyViewWebApp.Server.Services.AmenitiesServices
{
    public interface IAmenitiesService
    {
        //Amenities Creation
        Task<bool> CreateAmenitiesAsync(AmenitiesCreate model);

        //Amenities Get all
        Task<IEnumerable<AmenitiesGetAll>> GetAllAmenitiesAsync();

        //Update Amenities
        Task<bool> UpdateAmenitiesAsnc(AmenitiesUpdate request);

        //Delete Amenities
        Task<bool> DeleteAmenitiesAsync(int amenitiesId);
    }
}
