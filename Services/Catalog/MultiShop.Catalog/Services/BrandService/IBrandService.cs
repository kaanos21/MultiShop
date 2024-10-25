using MultiShop.Catalog.Dtos.BrandDtos;

namespace MultiShop.Catalog.Services.BrandService
{
    public interface IBrandService
    {
        Task<List<ResultBrandDtos>> GetAllBrandAsync();
        Task CreateBrandAsync(CreateBrandDtos createDategoryDto);
        Task UpdateBrandAsync(UpdateBrandDtos updateBrandDto);
        Task DeleteBrandAsync(string id);
        Task<GetByIdBrandDtos> GetByIdBrandAsync(string id);
    }
}
