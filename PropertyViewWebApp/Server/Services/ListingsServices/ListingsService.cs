using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertyViewWebApp.Server.Data;
using PropertyViewWebApp.Server.Models;
using PropertyViewWebApp.Shared.Models.Amenities;
using PropertyViewWebApp.Shared.Models.Listings;
using PropertyViewWebApp.Shared.Models.TypeOfListing;

namespace PropertyViewWebApp.Server.Services.ListingsServices
{
    public class ListingsService : IListingsService
    {
        private readonly ApplicationDbContext _context;

        public ListingsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddListingstoAmenitiesAsync(int listingsId, AddListingsToAmenities request)
        {
            var listingsEntity = await _context.Listings.FindAsync(request.Id);
            var amenitiesEntity = await _context.Amenitites
                .Include(a => a.Listings)
                .FirstOrDefaultAsync(a => a.Id == request.Id);

            if (request.Id == listingsId)
            {
                amenitiesEntity.Listings.Add(listingsEntity);
                var numberOfChanges = await _context.SaveChangesAsync();
                return numberOfChanges == 1;
            }

            return false;
        }

        public async Task<bool> CreateListingsAsync(ListingsCreate model)
        {
            var listingsEntity = new Listings
            {
                Name = model.Name,
                Price = model.Price,
                NumberOfBeds = model.NumberOfBeds,
                NumberOfBaths = model.NumberOfBaths,
                Squarefeet = model.Squarefeet
            };

            _context.Listings.Add(listingsEntity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }


        public async Task<IEnumerable<ListingsGetAll>> GetAllListingsAsync()
        {
            var listings = await _context.Listings
                .Select(entity => new ListingsGetAll
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Price = entity.Price,
                    NumberOfBeds = entity.NumberOfBeds,
                    NumberOfBaths = entity.NumberOfBaths
                }).ToListAsync();

            return listings;
        }

        public async Task<ListingsDetail> GetListingsDetailAsync(int listingsId)
        {
            var listings = await _context.Listings
                .Include(a => a.Amenitites)
                .Include(t => t.TypeOfListing)
                .FirstOrDefaultAsync(l => l.Id == listingsId);
            return listings is null ? null : new ListingsDetail
            {
                Id = listings.Id,
                Name = listings.Name,
                Price = listings.Price,
                NumberOfBeds = listings.NumberOfBeds,
                NumberOfBaths = listings.NumberOfBaths,
                Squarefeet = listings.Squarefeet,
                Amenities = listings.Amenitites.Select(a => new AmenitiesGetAll
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList(),
                Type = new TypeOfListingGetAll
                {
                    Id = listings.amenitiesId ?? 0,
                    Name = listings.TypeOfListing?.Name,
                }
            };
        }

        public async Task<bool> UpdateListingsAsync(ListingsUpdate model)
        {
            var listingsUpdate = await _context.Listings.FindAsync(model.Id);
            listingsUpdate.Name = (model.Name ?? listingsUpdate.Name);
            listingsUpdate.Price = (model.Price ?? listingsUpdate.Price);
            listingsUpdate.NumberOfBeds = (model.NumberOfBeds ?? listingsUpdate.NumberOfBeds);
            listingsUpdate.NumberOfBaths = (model.NumberOfBaths ?? listingsUpdate.NumberOfBaths);
            listingsUpdate.Squarefeet = (model.Squarefeet ?? listingsUpdate.Squarefeet);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteListingsAsync(int listingsId)
        {
            var listingsDelete = await _context.Listings.FindAsync(listingsId);

            _context.Listings.Remove(listingsDelete);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
