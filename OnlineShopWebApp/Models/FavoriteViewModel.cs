using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
	public class FavoriteViewModel
	{
		public Guid Id { get; set; }
		public string UserId { get; set; }
		public string ImagePath { get; set; }

		public List<ProductViewModel> Items { get; set; }
		public decimal Cost
		{
			get
			{
				return Items?.Sum(x => x.Cost) ?? 0;
			}
		}

		public ProductViewModel Product { get; internal set; }

		//public decimal Amount
		//{
		//	get
		//	{
		//		return Items?.Sum(x => x.Amount) ?? 0;
		//	}
		//}
	}
}
