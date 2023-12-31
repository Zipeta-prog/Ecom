using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders.Models.Dtos;
using Orders.Services.IService;

namespace Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ResponseDto _responseDto;
        private readonly IOrder _orderService;
        public OrderController(IMapper mapper, ResponseDto responseDto, IOrder orderService)
        {
            _mapper = mapper;
            _responseDto = responseDto;
            _orderService = orderService;
        }

        [HttpPost("Pay")]

        public async Task<ActionResult<ResponseDto>> makePayments(StripeRequestDto dto)
        {

            var sR = await _orderService.MakePayments(dto);

            _responseDto.Result = sR;
            return Ok(_responseDto);
        }

        [HttpPost("validate/{Id}")]

        public async Task<ActionResult<ResponseDto>> validatePayment(Guid Id)
        {

            var res = await _orderService.ValidatePayments(Id);

            if (res)
            {
                _responseDto.Result = res;
                return Ok(_responseDto);
            }

            _responseDto.Errormessage = "Payment Failed!";
            return BadRequest(_responseDto);
        }

        [HttpGet("{userId}")]

        public async Task<ActionResult<ResponseDto>> GetUserBooking(Guid userId)
        {
            var res = await _orderService.GetAll(userId);
            _responseDto.Result = res;
            return Ok(_responseDto);
        }
    }    
}
