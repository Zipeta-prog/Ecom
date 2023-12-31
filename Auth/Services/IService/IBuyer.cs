using Auth.Models;
using Auth.Models.Dtos;

namespace Auth.Services.IService
{
    public interface IBuyer
    {
        Task<string> RegisterBuyer(RegisterUserDto userDto);

        Task<LoginResponseDto> loginBuyer(LoginRequestDto loginRequestDto);

        Task<bool> AssignBuyerRoles(string Email, string RoleName);

        Task<Buyers> GetBuyerById(string Id);
        Task userRegistration(RegisterUserDto registerUser);
    }
}
