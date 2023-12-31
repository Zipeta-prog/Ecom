using Auth.Models.Dtos;
using Auth.Services;
using Auth.Services.IService;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcomMessageBus;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyersController : ControllerBase
    {
        private readonly IBuyer _buyersService;
        private readonly ResponseDto _response;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public BuyersController(IBuyer user, IConfiguration configuration, IMapper mapper)
        {
            _buyersService = user;
            _configuration = configuration;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto>> RegisterBuyer(RegisterUserDto registerUserDto)
        {
            var res = await _buyersService.RegisterBuyer(registerUserDto);

            if (string.IsNullOrWhiteSpace(res))
            {
                //this was success
                _response.Result = "User Registered Successfully";

                //add message to queue

                var message = new UserMessageDto()
                {
                    Name = registerUserDto.Name,
                   Email = registerUserDto.Email,
                };

                var mb = new MessageBus();
                await mb.PublishMessage(message, _configuration.GetValue<string>("Servicebus:register"));

                return Created("", _response);
            }

            _response.Errormessage = res;
            _response.IsSuccess = false;
            return BadRequest(_response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseDto>> loginBuyer(LoginRequestDto loginRequestDto)
        {
            var res = await _buyersService.loginBuyer(loginRequestDto);

            if (res.User != null)
            {
                //this was success
                _response.Result = res;
                return Created("", _response);
            }

            _response.Errormessage = "Invalid Credentials";
            _response.IsSuccess = false;
            return BadRequest(_response);
        }

        [HttpPost("register/")]
        public async Task<ActionResult<ResponseDto>> RegisterUSer(RegisterUserDto registerUser)
        {
            var res = await _buyersService.userRegistration(registerUser);

            if (res.User != null)
            {
                //this was success
                _response.Result = res;
                return Created("", _response);
            }

            _response.Errormessage = "Invalid Credentials";
            _response.IsSuccess = false;
            return BadRequest(_response);
        }


        [HttpPost("AssignRole")]
        public async Task<ActionResult<ResponseDto>> AssignRole(AssignRoleDto role)
        {
            var res = await _buyersService.AssignBuyerRoles(role.Email, role.Role);

            if (res)
            {
                //this was success
                _response.Result = res;
                return Ok(_response);
            }

            _response.Errormessage = "Error Occured ";
            _response.Result = res;
            _response.IsSuccess = false;
            return BadRequest(_response);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ResponseDto>> GetBuyer(string Id)
        {
            var res = await _buyersService.GetBuyerById(Id);
            var user = _mapper.Map<UserDto>(res);
            if (res != null)
            {
                //this was success
                _response.Result = user;
                return Ok(_response);
            }

            _response.Errormessage = "User Not found ";
            _response.IsSuccess = false;
            return NotFound(_response);
        }
    }
}
