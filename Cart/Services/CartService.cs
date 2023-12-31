using Cart.Data;
using Cart.Models;
using Cart.Services.IService;
using Microsoft.EntityFrameworkCore;


namespace Cart.Services
{
    public class CartService : ICart
    {
        private readonly ApplicationDbContext _context;
        private readonly IProduct _productService;
        private readonly IBuyer _userService;
        //private readonly IMessage _messageBUs;
        public async Task<string> AddCart(Carts booking)
        {
            _context.Carts.Add(booking);
            await _context.SaveChangesAsync();
            return "Booking added successfully";
        }

        public async Task<List<Carts>> GetAll(Guid userId)
        {
            return await _context.Carts.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Carts> GetCartById(Guid Id)
        {
            return await _context.Carts.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task saveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
