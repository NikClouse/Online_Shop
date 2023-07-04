﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Db.Models
{

	[Table("Orders")]
	public class Order
	{


		public Guid Id { get; set; }
		public UserDeliveryInfo User { get; set; }
		public List<CartItem> Items { get; set; }
		public OrderStatus Status { get; set; }
		public DateTime CreateDateTime { get; set; }


		public Order()
		{
			Status = OrderStatus.Created;
			CreateDateTime = DateTime.Now;
		}
	}
}
