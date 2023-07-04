using OnlineShopWebApp.Areas.Admin.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Интерфейсы
{
	public interface IUsersManager
	{
		void Add(UserViewModel user);
		void ChangePassword(string userName, string newPassword);
		List<UserViewModel> GetAll();
		object TryGet(string userName, string phone, string password);
		UserViewModel TryGetByName(string name);
		void RemoveAll(string name);
		void Update(UserViewModel userAccount);
	}
}
