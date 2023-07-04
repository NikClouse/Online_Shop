using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProductRepozitory productRepozitory;
        private readonly ICartRepozitory cartRepozitory;

        public CartController(ICartRepozitory cartRepozitory, IProductRepozitory productsRepozitory)
        {
            this.productRepozitory = productsRepozitory;
            this.cartRepozitory = cartRepozitory;
        }

        public IActionResult Index()
        {
            var cart = cartRepozitory.TryGetById(Constans.UserId);
            var cartViewModel = Mapping.ToCartViewModel(cart);
            return View(cartViewModel);
        }

        public IActionResult Add(Guid productId)
        {
            var product = productRepozitory.TryGetById(productId);
            cartRepozitory.Add(product, Constans.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid productId)
        {
            var product = productRepozitory.TryGetById(productId);
            cartRepozitory.Remove(product, Constans.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            cartRepozitory.Clear(Constans.UserId);
            return RedirectToAction("Index");
        }


    }
}
