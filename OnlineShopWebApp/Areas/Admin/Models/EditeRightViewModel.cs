using System.Collections.Generic;

namespace OnlineShopWebApp.Areas.Admin.Models
{
	public class EditeRightViewModel
	{
		public string UserName { get; set; }
		public List<RoleViewModel> Roles { get; set; }
		public List<RoleViewModel> AllRoles { get; set; }

	}
}
