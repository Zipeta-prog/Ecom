using Cart.Models.Dtos;

namespace Cart.Services.IService
{
    public interface IBuyer
    {
        Task<BuyerDto> GetBuyerById(string Id);
    }
}
