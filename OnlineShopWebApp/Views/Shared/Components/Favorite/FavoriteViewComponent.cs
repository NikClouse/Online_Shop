using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace OnlineShopWebApp.Views.Shared.Components.Favorite
{
	public class FavoriteViewComponent : ViewComponent
	{
		private readonly IFavorite favorite;

		public FavoriteViewComponent(IFavorite favorite)
		{
			this.favorite = favorite;
		}

		public IViewComponentResult Invoke()
		{
			//var productsCount = favorite.TryGetByIdFavorite(Constans.UserId).Count;
			//var productCount = cart?.Amount ?? 0;

			var productsCount = favorite.GetAll(Constans.UserId).Count;

			return View("Favorite", productsCount);
		}
	}
}
