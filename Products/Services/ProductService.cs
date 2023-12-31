using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Model;
using Products.Model.Dtos;
using Products.Services.IService;

namespace Products.Services
{
    public class ProductService : IProduct
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddNewProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return "Added new Item";
        }

        public async Task<List<ProductandPicResponseDto>> GetAllProducts()
        {
            return await _context.Products.Select(t => new ProductandPicResponseDto()
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Price = (int)t.Price,
                Pics = t.Pics.Select(x => new AddProductPicDto()
                {
                    Pic = x.Pic
                }).ToList()
            }).ToListAsync();
        }

        public async Task<Product> GetProduct(Guid Id)
        {
            return await _context.Products.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
    }
}
