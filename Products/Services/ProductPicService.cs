using Products.Data;
using Products.Model;
using Products.Services.IService;

namespace Products.Services
{
    public class ProductPicService : IPic
    {
        private readonly ApplicationDbContext _context;
        public ProductPicService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddPic(Guid Id, ProductPic pics)
        {
            var product = _context.Products.Where(x => x.Id == Id).FirstOrDefault();
            product.Pics.Add(pics);
            await _context.SaveChangesAsync();
            return "Image Added!!!";
        }
    }
}
