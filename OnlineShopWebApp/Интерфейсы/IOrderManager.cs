using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Интерфейсы
{
	public interface IOrderManager
	{
		OrderViewModel TryGetById(string userId);
		void Save(OrderViewModel order, CartViewModel cart, string userId);
		void Add(OrderViewModel order, CartViewModel cart, string userId);
		List<OrderViewModel> GetAll();
		OrderViewModel TryGetId(Guid id);
		void UpdateStatus(Guid orderId, OrderStatusViewModel newStatus);
		void Add(OrderViewModel order);
	}
}
