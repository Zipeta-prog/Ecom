using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Model;
using Products.Model.Dtos;
using Products.Services.IService;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicController : ControllerBase
    {
        private readonly IProduct _productService;
        private readonly IPic _picService;
        private readonly IMapper _mapper;
        private readonly ResponseDto _responseDto;
        public PicController(IMapper mapper, IPic pic, IProduct product)
        {
            _picService = pic;
            _productService = product;
            _mapper = mapper;
            _responseDto = new ResponseDto();
        }

        [HttpPost("{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseDto>> AddImage(Guid Id, AddProductPicDto addProductPicDto)
        {
            var product = await _productService.GetProduct(Id);

            if (product == null)
            {
                _responseDto.Errormessage = "Tour Not Found";
                return NotFound(_responseDto);
            }

            var image = _mapper.Map<ProductPic>(addProductPicDto);
            var res = await _picService.AddPic(Id, image);
            _responseDto.Result = res;
            return Created("", _responseDto);

        }
    }
}
