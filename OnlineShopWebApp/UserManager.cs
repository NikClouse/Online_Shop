using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Интерфейсы;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
	public class UserManager : IUsersManager
	{
		private readonly IUsersManager _usersManager;
		private readonly List<UserViewModel> users = new List<UserViewModel>();

		public List<UserViewModel> GetAll()
		{
			return users;
		}

		public void Add(UserViewModel user)
		{
			users.Add(user);
		}

		public UserViewModel TryGetByName(string name)
		{
			return users.FirstOrDefault(x => x.Name == name);
		}

		public void ChangePassword(string newPassword)
		{
			var account = TryGetByName(newPassword);
			account.Password = newPassword;
		}


		public object TryGet(string name, string phone, string password)
		{
			return users.FirstOrDefault(item =>
			item.Name == name && item.Password == password && item.Phone == phone);
		}

		public void ChangePassword(string userName, string newPassword)
		{
			var account = TryGetByName(userName);
			account.Password = newPassword;
		}

		public void RemoveAll(string name)
		{
			var account = users.FirstOrDefault(x => x.Name == name);
			users.Remove(account);
			users.Clear();


		}



		public void Update(UserViewModel userAccount)
		{
			var account = users.FirstOrDefault(x => x.Name != userAccount.Name);
			if (account != null)
			{

				account.Name = userAccount.Name;
				account.Phone = userAccount.Phone;

			}
			return;


		}
	}
}
