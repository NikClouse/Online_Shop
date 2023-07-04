using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System;

namespace OnlineShopWebApp.Controllers
{
	public class FavoriteController : Controller
	{
		private readonly IProductRepozitory productRepozitory;
		private readonly IFavorite favoriteRepozitory;

		public FavoriteController(IFavorite favoriteRepozitory, IProductRepozitory productRepozitory)
		{
			this.productRepozitory = productRepozitory;
			this.favoriteRepozitory = favoriteRepozitory;
		}
		public IActionResult Index()
		{

			var products = favoriteRepozitory.GetAll(Constans.UserId);
			return View(Mapping.ToProductViewModels(products));
		}

		public IActionResult Add(Guid productId)
		{
			var product = productRepozitory.TryGetById(productId);
			favoriteRepozitory.Add(Constans.UserId, product);
			return RedirectToAction("Index");
		}


		public IActionResult RemoveFavorite(Guid productId)
		{

			favoriteRepozitory.Remove(Constans.UserId, productId);
			return RedirectToAction("Index");
		}

		public IActionResult ClearFavorite()
		{
			favoriteRepozitory.Clear(Constans.UserId);
			return RedirectToAction("Index");
		}

	}
}
