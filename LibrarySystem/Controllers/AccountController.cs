using Library.Service;
using Library.Service.Interface;
using LibrarySystem.Helper;
using LibrarySystem.Presentation.Filters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibrarySystem.Controllers
{
    [ServiceFilter(typeof(GlobalActionFilter))]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string UserName, string password)
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Please enter both username and password";
                return View();
            }

            var hashedPassword = PasswordHasher.HashPassword(password);

       
            var user = await _userService.Login(UserName, hashedPassword);
            if (user != null)
            {
                
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                 };

           
                var claimsIdentity = new ClaimsIdentity(claims, "Library");

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync("Library", claimsPrincipal, new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
                });

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(string username, string email, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match";
                return View();
            }
            var hashedpassword=PasswordHasher.HashPassword(password);
            var result = await _userService.Register(username, email, hashedpassword);
            if (result)
            {
                return RedirectToAction("Login");
            }

            ViewBag.Error = "Registration failed. Please try again.";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Library");

            return RedirectToAction("Login", "Account");
        }
    }
}