using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
	[Authorize]
	public class OrderController : Controller
	{
		private readonly ICartRepozitory cartsRepozitory;
		private readonly IOrderRepozitory orderRepozitory;
		private readonly UserManager<User> userManager;


		public OrderController(ICartRepozitory cartsRepozitory, IOrderRepozitory orderRepozitory)
		{
			this.cartsRepozitory = cartsRepozitory;
			this.orderRepozitory = orderRepozitory;
		}

		public IActionResult Index()
		{

			return View();
		}

		[HttpPost]
		public IActionResult Buy(UserDeliveryInfoViewModel user)
		{
			if (!ModelState.IsValid)
			{
				return View(user);
			}

			var existingCart = cartsRepozitory.TryGetById(Constans.UserId);

			//var existingCartViewModel = Mapping.ToCartViewModel(existingCart);
			//var cart = cartsRepozitory.TryGetById(Constans.UserId);

			var order = new Order
			{
				User = user.ToUser(),
				Items = existingCart.Items,
			};
			orderRepozitory.Add(order);
			cartsRepozitory.Clear(Constans.UserId);
			return View();
		}



	}
}
