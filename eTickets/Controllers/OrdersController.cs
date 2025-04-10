using etickets.Service.UnitOfWork;
using eTickets.Data.Data.Cart;
using eTickets.Data.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using ZendeskApi_v2.Models.Constants;

namespace eTickets.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ShoppingCart _shoppingCart;

        private readonly IUnitOfWork _unitOfWork;
       
        public OrdersController( ShoppingCart shoppingCart, IUnitOfWork unitOfWork)
        {
            _shoppingCart = shoppingCart;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);


            var orders =await _unitOfWork.Orders.GetOrderByUserIdAndRoleAsync(userId,userRole);
            return View(orders);
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _unitOfWork.Movies.GetMovieByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _unitOfWork.Movies.GetMovieByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public async Task<IActionResult> CompleteOrder()
        {
            var items=_shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _unitOfWork.Orders.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();
                
            return View("CompleteOrder");
        }
    }
}
