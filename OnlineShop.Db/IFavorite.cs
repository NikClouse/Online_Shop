using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
	public interface IFavorite
	{
		void Add(string userId, Product product);
		void Clear(string userId);
		List<Product> GetAll(string userId);
		void Remove(string userId, Guid productId);
	}
}