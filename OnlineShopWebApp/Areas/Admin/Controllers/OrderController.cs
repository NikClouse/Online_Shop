using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{

	[Area(Constans.AdminRoleName)]
	[Authorize(Roles = Constans.AdminRoleName)]


	public class OrderController : Controller
	{
		private readonly IOrderRepozitory orderRepozitory;
		public OrderController(IOrderRepozitory orderRepozitory)
		{
			this.orderRepozitory = orderRepozitory;
		}
		public IActionResult Index()
		{
			var orders = orderRepozitory.GetAll();
			return View(orders.Select(x => Mapping.ToOrderViewModel(x)).ToList());
		}

		public IActionResult Details(Guid orderId)
		{
			var order = orderRepozitory.TryGetById(orderId);
			return View(Mapping.ToOrderViewModel(order));
		}

		public IActionResult UpdateOrderStatus(Guid orderId, OrderStatusViewModel status)
		{
			orderRepozitory.UpdateStatus(orderId, (OrderStatus)(int)status);
			return RedirectToAction(nameof(Index));
		}

	}
}
