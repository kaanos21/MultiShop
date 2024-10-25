using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Services.BrandService;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _BrandService;

        public BrandsController(IBrandService BrandService)
        {
            _BrandService = BrandService;
        }
        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _BrandService.GetAllBrandAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDtos createBrandDto)
        {
            await _BrandService.CreateBrandAsync(createBrandDto);
            return Ok("Ürün başarıyla eklendi");
        }
        [HttpGet("GetBrandById")]
        public async Task<IActionResult> GetBrandById(string id)
        {
            var values = await _BrandService.GetByIdBrandAsync(id);
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _BrandService.DeleteBrandAsync(id);
            return Ok(" Başarı İle Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDtos updateBrand)
        {
            await _BrandService.UpdateBrandAsync(updateBrand);
            return Ok("Başarı ile Güncellendi");
        }
    }
}
