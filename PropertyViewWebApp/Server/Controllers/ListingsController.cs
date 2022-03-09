using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyViewWebApp.Server.Services.ListingsServices;
using PropertyViewWebApp.Shared.Models.Listings;

namespace PropertyViewWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly IListingsService _listingsService;

        public ListingsController(IListingsService listingsService)
        {
            _listingsService = listingsService;
        }

        public async Task<IActionResult> Index()
        {
            var listings = await _listingsService.GetAllListingsAsync();
            return Ok(listings);
        }

        [HttpPost]
        public async Task<IActionResult> CreateListings(ListingsCreate model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();

            bool wasSuccessful = await _listingsService.CreateListingsAsync(model);

            if (wasSuccessful) return Ok();
            return UnprocessableEntity();
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllListings()
        //{
        //    var listings = await _listingsService.GetAllListingsAsync();
        //    return Ok(listings);
        //}

        [HttpGet("{listingsId:int}")]
        public async Task<IActionResult> GetListingsDetail(int listingsId)
        {
            var listings = await _listingsService.GetListingsDetailAsync(listingsId);

            return listings is not null
                ? Ok(listings)
                : NotFound();
        }

        [HttpPut("update/{listingsId:int}")]
        public async Task<IActionResult> UpdateListings(ListingsUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _listingsService.UpdateListingsAsync(request)
                ? Ok()
                : BadRequest();
        }

        [HttpDelete("delete/{listingsId:int}")]
        public async Task<IActionResult> DeleteListings(int listingsId)
        {
            return await _listingsService.DeleteListingsAsync(listingsId)
                ? Ok()
                : BadRequest();
        }

        [HttpPut("addAmenity/{listingsId:int}")]
        public async Task<IActionResult> AddListingsToAmenities(int listingsId, [FromBody] AddListingsToAmenities request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _listingsService.AddListingstoAmenitiesAsync(listingsId, request)
                ? Ok()
                : BadRequest();
        }
    }
}