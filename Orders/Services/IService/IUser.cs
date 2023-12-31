using Orders.Models.Dtos;

namespace Orders.Services.IService
{
    public interface IUser
    {
        Task<UserDto> GetUserById(string Id);
    }
}
