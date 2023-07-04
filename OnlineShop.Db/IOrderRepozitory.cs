
using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
	public interface IOrderRepozitory
	{
		List<Order> GetAll();
		//void Add(Order order, Cart cart, Guid userId);
		void Add(Order order);
		Order TryGetById(Guid id);
		void UpdateStatus(Guid orderId, OrderStatus newStatus);
	}
}