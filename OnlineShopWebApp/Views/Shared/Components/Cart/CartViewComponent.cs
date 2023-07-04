using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
	public class CartViewComponent : ViewComponent
	{
		private readonly ICartRepozitory cartRepozitory;

		public CartViewComponent(ICartRepozitory cartRepozitory)
		{
			this.cartRepozitory = cartRepozitory;
		}

		public IViewComponentResult Invoke()
		{
			var cart = cartRepozitory.TryGetById(Constans.UserId);

			var cartViewModel = Mapping.ToCartViewModel(cart);

			var productCount = cartViewModel?.Amount ?? 0;

			return View("Cart", productCount);
		}

	}
}
