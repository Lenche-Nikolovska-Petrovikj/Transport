using Application.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.MVC.Controllers
{

    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel userM)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { UserName = userM.UserName, Email = userM.Email };
                var result = await _userManager.CreateAsync(user, userM.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(userM);
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByNameAsync(userModel.Username);
                    if (user != null)
                    {
                        await _signInManager.SignInAsync(user, userModel.RememberMe);
                        return RedirectToAction("Index", "Transport");
                    }
                    ModelState.AddModelError(nameof(userModel.Username), "SinIn Failed: Invalid Email or password");
                }
                catch (System.Exception ex)
                {

                    throw ex;
                } 
            }
            return View(userModel);
            /*{
                
                try
                {
                    var user = await _userManager.FindByNameAsync(userModel.Username);
                    var password = await _userManager.CheckPasswordAsync(user, userModel.Password);

                    var signInResult = await _signInManager.PasswordSignInAsync(user, userModel.Password, userModel.RememberMe, false);
                   
                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Transport");
                    }
                    return View(userModel);

                }
                catch (System.Exception ex)
                {
                    return View(userModel);
                    //throw ex;
                }
                
            }*/
            
        }
        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn");
        }
    }
}
