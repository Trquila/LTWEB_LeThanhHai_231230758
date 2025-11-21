using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Success(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        public IActionResult Track()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Track(string orderCode, string customerPhone)
        {
            if (string.IsNullOrEmpty(orderCode) || string.IsNullOrEmpty(customerPhone))
            {
                ModelState.AddModelError("", "Vui lòng nhập mã đơn hàng và số điện thoại");
                return View();
            }

            if (int.TryParse(orderCode, out int orderId))
            {
                var order = await _context.Orders
                    .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                    .FirstOrDefaultAsync(o => o.Id == orderId && o.CustomerPhone == customerPhone);

                if (order != null)
                {
                    return View("OrderDetail", order);
                }
            }

            ModelState.AddModelError("", "Không tìm thấy đơn hàng với thông tin đã nhập");
            return View();
        }
    }
}