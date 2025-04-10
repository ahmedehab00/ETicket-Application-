using eTickets.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.service.service
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> item, string userId, string userEmailAddress);

        Task<List<Order>>GetOrderByUserIdAndRoleAsync(string userId, string userRole);
    }
}
