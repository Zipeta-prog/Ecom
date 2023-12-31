using Cart.Models;

namespace Cart.Services.IService
{
    public interface ICart
    {
        Task<string> AddCart(Carts booking);

        Task saveChanges();

        Task<List<Carts>> GetAll(Guid userId);

        Task<Carts> GetCartById(Guid Id);
    }
}
