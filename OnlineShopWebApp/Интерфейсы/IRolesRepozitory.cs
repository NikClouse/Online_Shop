using OnlineShopWebApp.Areas.Admin.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Интерфейсы
{
    public interface IRolesRepozitory
	{

		List<RoleViewModel> GetAll();
		RoleViewModel TryGetById(string name);
		void Add(RoleViewModel role);
		void Remove(string name);
		RoleViewModel TryGetByName(string name);
	}
}
