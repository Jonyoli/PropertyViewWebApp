using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyViewWebApp.Server.Services.AmenitiesServices;
using PropertyViewWebApp.Shared.Models.Amenities;

namespace PropertyViewWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenitiesService _amenitiesService;

        public AmenitiesController(IAmenitiesService amenitiesService)
        {
            _amenitiesService = amenitiesService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAmenities(AmenitiesCreate newAmenities)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _amenitiesService.CreateAmenitiesAsync(newAmenities))
                return Ok();

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAmenities()
        {
            var amenities = await _amenitiesService.GetAllAmenitiesAsync();
            return Ok(amenities);
        }

        [HttpPut("update/{amenitiesId:int}")]
        public async Task<IActionResult> UpdateAmenities(AmenitiesUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _amenitiesService.UpdateAmenitiesAsnc(request)
                ? Ok()
                : BadRequest();
        }

        [HttpDelete("delete/{amenitiesId:int}")]
        public async Task<IActionResult> DeleteAmenities(int amenitiesId)
        {
            return await _amenitiesService.DeleteAmenitiesAsync(amenitiesId)
                ? Ok()
                : BadRequest();
        }
    }
}
