using Orders.Models;
using Orders.Models.Dtos;

namespace Orders.Services.IService
{
    public interface IOrder
    {
        Task<string> AddOrder(Order booking);
        Task saveChanges();
        Task<List<Order>> GetAll(Guid userId);
        Task<Order> GetOrderById(Guid Id);
        Task<StripeRequestDto> MakePayments(StripeRequestDto stripeRequestDto);
        Task<bool> ValidatePayments(Guid BookingId);
    }
}
