using API.Model;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WisataSamosir.Base.Controllers;
using WisataSamosir.Handler;
using WisataSamosir.Repository.Data;

namespace WisataSamosir.Controllers
{
    public class AuthsController : BaseController<Account, AuthRepository,int>
    {
        private readonly AuthRepository repository;

        public AuthsController(AuthRepository repository)   :  base(repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            LoginVM loginVM = new LoginVM();
            loginVM.Email = Email;
            loginVM.Password = Password;
            var jwtToken = await repository.Login(loginVM);
            var token = jwtToken.Token;

            if (token == null)
            {
                return RedirectToAction("Login", "Auths", new { err = jwtToken.Message });
            }
            HttpContext.Session.SetString("JWToken", token);
            string Roles = JWTHandler.GetClaim(token, "role");
            HttpContext.Session.SetString("role", Roles);
            return RedirectToAction("Index", "Dashboards");
        }

        [Authorize]
        [HttpGet("Logout/")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Auths");
        }
    }
}
