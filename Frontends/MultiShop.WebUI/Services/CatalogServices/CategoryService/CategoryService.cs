using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateCategoryAsync(CreateCategoryDto createcategoryDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories",createcategoryDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            //Categories/GetCategoryById?id=4
            await _httpClient.DeleteAsync("Categories?id="+id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var responseMessage=  await _httpClient.GetAsync("Categories");
            var values=await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values;
            
        }

        public async Task<UpdateCategoryDto> GetByIdCategoryAsync(string id)
        {
            //Categories/GetCategoryById?id=4
            var responseMessage = await _httpClient.GetAsync("Categories/GetCategoryById?id="+id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCategoryDto>();
            return values;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories",updateCategoryDto);
        }
    }
}
