using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertyViewWebApp.Server.Data;
using PropertyViewWebApp.Server.Models;
using PropertyViewWebApp.Shared.Models.Amenities;

namespace PropertyViewWebApp.Server.Services.AmenitiesServices
{
    public class AmenitiesService : IAmenitiesService
    {
        private readonly ApplicationDbContext _context;

        public AmenitiesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAmenitiesAsync(AmenitiesCreate model)
        {
            var amenitiesEntity = new Amenities
            {
                Name = model.Name
            };

            _context.Amenities.Add(amenitiesEntity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }


        public async Task<IEnumerable<AmenitiesGetAll>> GetAllAmenitiesAsync()
        {
            var amenities = await _context.Amenities
                .Select(entity => new AmenitiesGetAll
                {
                    Id = entity.Id,
                    Name = entity.Name
                }).ToListAsync();

            return amenities;
        }

        public async Task<bool> UpdateAmenitiesAsnc(AmenitiesUpdate request)
        {
            var amenitiesUpdate = await _context.Amenities.FindAsync(request.Id);
            amenitiesUpdate.Name = (request.Name ?? amenitiesUpdate.Name);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteAmenitiesAsync(int amenitiesId)
        {
            var amenitiesDelete = await _context.Amenities.FindAsync(amenitiesId);

            _context.Amenities.Remove(amenitiesDelete);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
