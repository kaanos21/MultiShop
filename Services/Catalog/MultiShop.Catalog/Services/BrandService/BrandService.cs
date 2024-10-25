using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandService
{
    public class BrandService:IBrandService
    {
        private readonly IMongoCollection<Brand> _BrandCollection;
        private readonly IMapper _mapper;

        public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _BrandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDtos createDategoryDto)
        {
            var value = _mapper.Map<Brand>(createDategoryDto);
            await _BrandCollection.InsertOneAsync(value);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _BrandCollection.DeleteOneAsync(x => x.BrandId == id);
        }

        public async Task<List<ResultBrandDtos>> GetAllBrandAsync()
        {
            var vv = await _BrandCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBrandDtos>>(vv);
        }

        public async Task<GetByIdBrandDtos> GetByIdBrandAsync(string id)
        {
            var values = await _BrandCollection.Find<Brand>(x => x.BrandId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdBrandDtos>(values);
        }

        public async Task UpdateBrandAsync(UpdateBrandDtos updateBrandDto)
        {
            var values = _mapper.Map<Brand>(updateBrandDto);
            await _BrandCollection.FindOneAndReplaceAsync(x => x.BrandId == updateBrandDto.BrandId, values);
        }
        }
    }

