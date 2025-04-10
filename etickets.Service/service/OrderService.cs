using eTickets.Data.Data;
using eTickets.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.service.service
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders =await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Movie).Include(n=>n.User).ToListAsync();
            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }
            return orders;      
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> item, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email=userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();


            foreach (var items in item)
            {
                var orderItem = new OrderItem()
                {
                    Amount = items.Amount,
                    MovieId=items.Movie.id,
                    OrderId=order.Id,
                    Price=items.Movie.price,
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
