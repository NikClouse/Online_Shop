using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
	[Area(Constans.AdminRoleName)]
	[Authorize(Roles = Constans.AdminRoleName)]
	public class UserController : Controller
	{
		private readonly UserManager<User> usersManager;
		private readonly RoleManager<IdentityRole> rolesManager;

		public UserController(UserManager<User> usersManager, RoleManager<IdentityRole> rolesManager)
		{
			this.usersManager = usersManager;
			this.rolesManager = rolesManager;
		}

		public IActionResult Index()
		{
			var userAccount = usersManager.Users.ToList();
			return View(userAccount.Select(x => x.ToUserViewModel()).ToList());

		}

		public IActionResult More(string name)
		{
			var userAccount = usersManager.FindByNameAsync(name).Result;
			return View(userAccount.ToUserViewModel());
		}

		public IActionResult ChangePassword(string name)
		{
			ChangePassword changePassword = new ChangePassword()
			{
				UserName = name
			};
			return View(changePassword);
		}

		[HttpPost]
		public IActionResult ChangePassword(ChangePassword changePassword)
		{
			if (changePassword.UserName == changePassword.Password)
			{
				ModelState.AddModelError("", "Логин и пароль не дольжны совпадать!");
			}
			if (ModelState.IsValid)
			{
				var userAccount = usersManager.FindByNameAsync(changePassword.UserName).Result;
				usersManager.PasswordHasher.HashPassword(userAccount, changePassword.Password);
				userAccount.PasswordHash = changePassword.Password;
				usersManager.UpdateAsync(userAccount).Wait();
				usersManager.ChangePasswordAsync(userAccount, "OldPassword", changePassword.Password);
				return RedirectToAction(nameof(Index));
			}
			return RedirectToAction(nameof(ChangePassword));
		}

		public IActionResult Dalete(string name)
		{
			var userAccount = usersManager.FindByNameAsync(name).Result;
			usersManager.DeleteAsync(userAccount).Wait();
			return RedirectToAction(nameof(Index));
		}


		public IActionResult Edit(UserViewModel userV)
		{
			var user = usersManager.FindByNameAsync(userV.Name).Result;
			var users = Mapping.ToUserViewModelEdit(user);
			return View(users);


		}
		[HttpPost]
		public IActionResult Edit(string s, UserViewModel user)
		{

			if (!ModelState.IsValid)
			{

				return View(user);
			}
			var userDb = usersManager.FindByIdAsync(user.Id).Result;
			userDb.PhoneNumber = user.Phone;
			userDb.Email = user.Email;
			userDb.UserName = user.Name;
			var result = usersManager.UpdateAsync(userDb).Result;//null
			return RedirectToAction(nameof(Index));

		}


		public IActionResult EditRight(string name)
		{
			var user = usersManager.FindByNameAsync(name).Result;
			var userRoles = usersManager.GetRolesAsync(user).Result;
			var roles = rolesManager.Roles.ToList();
			var model = new EditeRightViewModel
			{
				UserName = user.UserName,
				Roles = userRoles.Select(x => new RoleViewModel { Name = x }).ToList(),
				AllRoles = roles.Select(x => new RoleViewModel { Name = x.Name }).ToList()

			};
			return View(model);

		}

		[HttpPost]
		public IActionResult EditRight(string name, Dictionary<string, string> userRolesViewModel)
		{
			var userSelectedRoles = userRolesViewModel.Select(x => new IdentityRole(x.Key));
			var user = usersManager.FindByNameAsync(name).Result;
			var userRoles = usersManager.GetRolesAsync(user).Result;
			usersManager.RemoveFromRolesAsync(user, userRoles).Wait();

			return RedirectToAction("EditRight", name);
		}


	}
}
