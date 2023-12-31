﻿using System;
using System.Collections.Generic;


namespace OnlineShop.Db
{
	public class Cart
	{
		public Guid Id { get; set; }

		public string UserId { get; set; }

		public List<CartItem> Items { get; set; }

		public DateTime CreateDateTime { get; set; }

		public Cart()
		{
			CreateDateTime = DateTime.Now;
			Items = new List<CartItem>();
		}
	}
}