
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
	public interface IProductRepozitory
	{
		List<Product> GetAll();
		Product TryGetById(Guid id);
		void Add(Product product);
		void Update(Product product);
		void Remove(Guid productId);

	}
}