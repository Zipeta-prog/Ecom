using Cart.Data;
using Cart.Models.Dtos;
using Cart.Services.IService;
using Newtonsoft.Json;

namespace Cart.Services
{
    public class ProductService : IProduct
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ProductDto> GetById(Guid id)
        {
            var client = _httpClientFactory.CreateClient("Ecommerce");
            var response = await client.GetAsync(id.ToString());
            var content = await response.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<ResponseDto>(content);
            if (responseDto.Result != null && response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductDto>(responseDto.Result.ToString());
            }
            return new ProductDto();
        }

        public async Task GetById(object productId)
        {
            throw new NotImplementedException();
        }
    }
}
