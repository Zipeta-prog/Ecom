using AutoMapper;
using Cart.Models;
using Cart.Models.Dtos;
using Cart.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICoupon _couponService;
        private readonly ICart _cartService;
        private readonly IProduct _productService;
        private readonly ResponseDto _responseDto;

        public CartController(IMapper mapper, IProduct product, ICart cart, ICoupon coupon)
        {
            _cartService = cart;
            _mapper = mapper;
            _couponService = coupon;
            _productService = product;
            _responseDto = new ResponseDto();
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto>> AddCart(AddCartDto dto)
        {

            var cart = _mapper.Map<Carts>(dto);
            var product = await _productService.GetById(cart.ProductId);

            if (cart == null || product == null)
            {
                _responseDto.Errormessage = "Invalid Values";
                return NotFound(_responseDto);
            }

            var total = (product.Price);

            cart.CartTotal = total;

            var res = await _cartService.AddCart(cart);
            _responseDto.Result = res;
            return Ok(_responseDto);


        }
    }
}

