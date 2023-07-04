
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db.Models
{
	public class OrderDbRepozitory : IOrderRepozitory
	{
		private readonly DatabaseContext databaseContext;

		public OrderDbRepozitory(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public void Add(Order order)
		{
			databaseContext.Orders.Add(order);
			databaseContext.SaveChanges();
		}


		//public void Add(Order order, Cart cart, Guid userId)
		//{
		//	order.Id = userId;
		//	order.CreateDateTime = DateTime.Now;
		//	order.Status = OrderStatus.Created;
		//	order.Items = new List<CartItem>(cart.Items);
		//	databaseContext.Add(order);
		//}

		public List<Order> GetAll()
		{
			return databaseContext.Orders.Include(x => x.User).Include(x => x.Items).ThenInclude(x => x.Product).ToList();
		}

		public Order TryGetById(Guid id)
		{
			return databaseContext.Orders.Include(x => x.User).Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == id);
		}

		public void UpdateStatus(Guid orderId, OrderStatus newStatus)
		{
			var order = TryGetById(orderId);
			if (order != null)
			{
				order.Status = newStatus;
			}
			databaseContext.SaveChanges();
		}
	}
}

