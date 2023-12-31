using Cart.Models.Dtos;
using Cart.Services.IService;
using Newtonsoft.Json;

namespace Cart.Services
{
    public class BuyerService : IBuyer
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BuyerService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<BuyerDto> GetBuyerById(string Id)
        {
            var client = _httpClientFactory.CreateClient("Tours");
            var response = await client.GetAsync(Id.ToString());
            var content = await response.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (responseDto.Result != null && response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductDto>(responseDto.Result.ToString());
            }
            return new ProductDto();
        }
    }
}
