﻿namespace OnlineShopWebApp.Areas.Admin.Models
{
	public class UserViewModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Password { get; internal set; }

	}
}
