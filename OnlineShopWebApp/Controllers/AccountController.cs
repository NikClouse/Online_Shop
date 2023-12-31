﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
	public class AccountController : Controller
	{

		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;


		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
		{

			this.userManager = userManager;
			this.signInManager = signInManager;

		}

		public IActionResult Login(string returnUrl)
		{
			return View(new Login() { ReturnUrl = returnUrl });
		}

		[HttpPost]
		public IActionResult Login(Login login)
		{
			if (!ModelState.IsValid)
			{
				var result = signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false).Result;
				if (result.Succeeded)
				{
					return Redirect(login.ReturnUrl ?? "/Home");
				}
				else
				{
					ModelState.AddModelError("", "Неправилный парол");
				}
			}
			return View(login);


		}

		public IActionResult Logout()
		{
			signInManager.SignOutAsync().Wait();

			return RedirectToAction(nameof(HomeController.Index), "Home");
		}

		public IActionResult Register(string returnUrl)
		{
			return View(new Register() { ReturnUrl = returnUrl });
		}

		[HttpPost]
		public IActionResult Register(Register register)
		{
			if (register.UserName == register.Password)
			{
				ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
			}
			if (ModelState.IsValid)
			{
				User user = new User
				{
					Email = register.Email,
					UserName = register.UserName,
					PhoneNumber = register.Phone
				};
				var result = userManager.CreateAsync(user, register.Password).Result;
				if (result.Succeeded)
				{
					signInManager.SignInAsync(user, false).Wait();
					return Redirect(register.ReturnUrl ?? "/Home");
				}
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}

			}
			return View(register);
		}
	}
}
