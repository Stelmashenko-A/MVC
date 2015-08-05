using System.Web.Mvc;
using System.Web.Security;
using MVC.Authentication;
using MVC.Models;
using MVC.Repository;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        readonly IAccountRepository _accountRepository = new AccountRepository();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                User user = null;
                user = _accountRepository.GetUser(model);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View("Index");//return View("Index",model)
        }
        [HttpGet]
        public PartialViewResult Register()
        {
            return  PartialView("Registration",new RegisterModel());
        }

        [HttpGet]
        public ActionResult Login()
        {
            return PartialView("Login", new LoginModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _accountRepository.AddUnique(model);
                if (result == AccountRepositoryState.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                if (result == AccountRepositoryState.UserIsNotUnique)
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
                if (result == AccountRepositoryState.SavingError)
                {
                    ModelState.AddModelError("", "Ошибка записи");
                }
                
            }

            return View("Index", model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}