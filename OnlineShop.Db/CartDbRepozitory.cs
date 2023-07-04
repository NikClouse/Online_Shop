using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
	public class CartDbRepozitory : ICartRepozitory
	{
		private readonly DatabaseContext databaseContext;

		public CartDbRepozitory(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		private List<Cart> carts = new List<Cart>();


		public Cart TryGetById(string userId)
		{
			return databaseContext.Carts.Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefault(cart => cart.UserId == userId);
		}

		public void Add(Product product, string userId)
		{
			var existingCart = TryGetById(userId);
			if (existingCart == null)
			{
				var newCart = new Cart
				{
					UserId = userId
				};
				newCart.Items = new List<CartItem>
				{
					new CartItem
					{
						Amount=1,
						Product = product,
						//Cart = newCart

					}
				};

				databaseContext.Carts.Add(newCart);
			}
			else
			{
				var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
				if (existingCartItem != null)
				{
					existingCartItem.Amount += 1;
				}
				else
				{
					existingCart.Items.Add(new CartItem
					{

						Amount = 1,
						Product = product,
						//Cart = existingCart
					});

				}
			}


			databaseContext.SaveChanges();
		}

		public void Remove(Product product, string userId)
		{
			var existingCart = TryGetById(userId);
			var existingCartItem = existingCart.Items.FirstOrDefault(item => item.Product.Id == product.Id);

			if (existingCartItem == null)
			{
				return;
			}

			existingCartItem.Amount -= 1;

			if (existingCartItem.Amount == 0)
			{
				existingCart.Items.Remove(existingCartItem);
			}
			databaseContext.SaveChanges();
		}

		public void Clear(string userId)
		{
			var existingCart = TryGetById(userId);
			databaseContext.Carts.Remove(existingCart);
			databaseContext.SaveChanges();
		}
	}
}