using Products.Model;

namespace Products.Services.IService
{
    public interface IPic
    {
        Task<string> AddPic(Guid Id, ProductPic pics);
    }
}
