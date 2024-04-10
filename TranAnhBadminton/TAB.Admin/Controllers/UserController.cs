using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using TAB.Admin.Services;
using TAB.ViewModels.System.Users;
using LoginRequest = TAB.ViewModels.System.Users.LoginRequest;


namespace TAB.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly InterfaceUserApiClient _userApiClient;
        public UserController(InterfaceUserApiClient userApiClient) 
        {
            _userApiClient = userApiClient;
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
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if(!ModelState.IsValid) { return View(ModelState); }

            var token = await _userApiClient.Authenticate(request);

            return View(token);
        }
    }
}
