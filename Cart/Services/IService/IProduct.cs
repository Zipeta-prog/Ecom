using Cart.Models.Dtos;

namespace Cart.Services.IService
{
    public interface IProduct
    {
        Task<ProductDto> GetById(Guid id);
        Task GetById(object productId);
    }
}
