using EcomMessageBus;
using Orders.Data;
using Orders.Models;
using Orders.Models.Dtos;
using Orders.Services.IService;

namespace Orders.Services
{
    public class OrderService : IOrder
    {
        private readonly OrderService _orderService;
        private readonly ApplicationDbContext _context;
        private readonly IMessageBus _messageBUs;
        private readonly IUser _userService;
        public OrderService(ApplicationDbContext context, IUser user, IMessageBus message)
        {
            _context = context;
            _userService = user;
            _messageBUs = message;

        }
        public Task<string> AddOrder(Order booking)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAll(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<StripeRequestDto> MakePayments(StripeRequestDto stripeRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task saveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidatePayments(Guid BookingId)
        {
            throw new NotImplementedException();
        }
    }
}
