using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Services.IService;
using AutoMapper;
using Products.Model.Dtos;
using Microsoft.AspNetCore.Authorization;
using Products.Model;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productService;

        private readonly IMapper _mapper;
        private readonly ResponseDto _responseDto;

        public ProductController(IMapper mapper, IPic pic, IProduct product)
        {

            _productService = product;
            _mapper = mapper;
            _responseDto = new ResponseDto();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseDto>> AddTour(AddProductDto addProductDto)
        {
            var product = _mapper.Map<Product>(addProductDto);
            var res = await _productService.AddNewProduct(product);
            _responseDto.Result = res;
            return Created("", _responseDto);
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto>> getProducts()
        {

            var res = await _productService.GetAllProducts();
            _responseDto.Result = res;
            return Ok(_responseDto);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ResponseDto>> getProduct(Guid Id)
        {

            var res = await _productService.GetProduct(Id);
            if (res == null)
            {
                _responseDto.Errormessage = "Product Not Found";
                return NotFound(_responseDto);
            }
            _responseDto.Result = res;
            return Ok(_responseDto);

        }
    }
}
