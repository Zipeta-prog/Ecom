using Auth.Data;
using Auth.Models;
using Auth.Models.Dtos;
using Auth.Services.IService;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Auth.Services
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwt _JwtServices;

        public UserService(ApplicationDbContext applicationDbContext, IMapper mapper, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IJwt jwtService)
        {
            _context = applicationDbContext;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _JwtServices = jwtService;
        }

        public async Task<bool> AssignUserRoles(string Email, string RoleName)
        {
            var user = await _context.ApplicationUsers.Where(x => x.Email.ToLower() == Email.ToLower()).FirstOrDefaultAsync();
            if (user == null)
            {
                return false;
            }
            else
            {
                if (!_roleManager.RoleExistsAsync(RoleName).GetAwaiter().GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole(RoleName));
                }
                await _userManager.AddToRoleAsync(user, RoleName);
                return true;
            }
        }

        public async Task<ApplicationUser> GetUserById(string Id)
        {
            return await _context.ApplicationUsers.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<LoginResponseDto> loginUser(LoginRequestDto loginRequestDto)
        {
            var user = await _context.ApplicationUsers.Where(x => x.UserName.ToLower() == loginRequestDto.UserName.ToLower()).FirstOrDefaultAsync();
            var isValid = _userManager.CheckPasswordAsync(user, loginRequestDto.Password).GetAwaiter().GetResult();

            if (!isValid || user == null)
            {
                return new LoginResponseDto();
            }
            var loggeduser = _mapper.Map<UserDto>(user);

            var roles = await _userManager.GetRolesAsync(user);

            var token = _JwtServices.GenerateToken(user, roles);

            var response = new LoginResponseDto()
            {
                User = loggeduser,
                Token = token
            };
            return response;
        }

        public async Task<string> RegisterUser(RegisterUserDto userDto)
        {
            try
            {
                var user = _mapper.Map<ApplicationUser>(userDto);
                var result = await _userManager.CreateAsync(user, userDto.Password);
                if (result.Succeeded)
                {
                    return string.Empty;
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
