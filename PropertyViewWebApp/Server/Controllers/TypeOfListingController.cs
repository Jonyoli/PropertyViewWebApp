using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyViewWebApp.Server.Services.TypeOfListingServices;
using PropertyViewWebApp.Shared.Models.TypeOfListing;

namespace PropertyViewWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfListingController : ControllerBase
    {
        private readonly ITypeOfListingService _typeService;

        public TypeOfListingController(ITypeOfListingService typeService)
        {
            _typeService = typeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateType(TypeOfListingCreate newType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _typeService.CreateTypeAsync(newType))
                return Ok();

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTypes()
        {
            var type = await _typeService.GetAllTypeAsync();
            return Ok(type);
        }

        [HttpPut("update/{typesId:int}")]
        public async Task<IActionResult> UpdateType(TypeOfListingUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _typeService.UpdateTypeAsnc(request)
                ? Ok()
                : BadRequest();
        }

        [HttpDelete("delete/{typesId:int}")]
        public async Task<IActionResult> DeleteType(int typeId)
        {
            return await _typeService.DeleteTypeAsync(typeId)
                ? Ok()
                : BadRequest();
        }
    }
}