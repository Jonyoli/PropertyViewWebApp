using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertyViewWebApp.Server.Data;
using PropertyViewWebApp.Server.Models;
using PropertyViewWebApp.Shared.Models.TypeOfListing;

namespace PropertyViewWebApp.Server.Services.TypeOfListingServices
{
    public class TypeOfListingService : ITypeOfListingService
    {
        private readonly ApplicationDbContext _context;

        public TypeOfListingService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddTypeToListings(int typeId, int listingsId)
        {
            var typeEntity = await _context.TypeOfListing.FindAsync(typeId);
            var listingsEntity = await _context.Listings.FindAsync(listingsId);
            listingsEntity.TypeOfListing = typeEntity;
            //listingsEntity = typeEntity.Listings;
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;

        }

        public async Task<bool> CreateTypeAsync(TypeOfListingCreate model)
        {
            var typeEntity = new TypeOfListing
            {
                Name = model.Name
            };
            _context.Add(typeEntity);

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }


        public async Task<IEnumerable<TypeOfListingGetAll>> GetAllTypeAsync()
        {
            var type = await _context.TypeOfListing
               .Select(entity => new TypeOfListingGetAll
               {
                   Id = entity.Id,
                   Name = entity.Name
               }).ToListAsync();

            return type;
        }

        public async Task<bool> UpdateTypeAsnc(TypeOfListingUpdate request)
        {
            var typeUpdate = await _context.TypeOfListing.FindAsync(request.Id);
            typeUpdate.Name = (request.Name ?? typeUpdate.Name);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteTypeAsync(int typeId)
        {
            var typeDelete = await _context.TypeOfListing.FindAsync(typeId);

            _context.TypeOfListing.Remove(typeDelete);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
