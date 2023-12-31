using Products.Model;
using Products.Model.Dtos;

namespace Products.Services.IService
{
    public interface IProduct
    {
        Task<List<ProductandPicResponseDto>> GetAllProducts();

        Task<Product> GetProduct(Guid Id);

        Task<string> AddNewProduct(Product tour);
    }
}
