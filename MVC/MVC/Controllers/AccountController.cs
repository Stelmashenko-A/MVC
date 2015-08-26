using System.Activities.Expressions;
using System.Web.Mvc;
using System.Web.Security;
using MVC.AOP;
using MVC.Authentication;
using MVC.Models;
using MVC.Repository;
using MVC.Unity;

namespace MVC.Controllers
{
    [LogAspect]
    public class AccountController : Controller
    {
        private readonly ICryptor _cryptor;
        private readonly IAccountRepository _accountRepository;

        public AccountController(ICryptor cryptor, IAccountRepository accountRepository)
        {
            _cryptor = cryptor;
            _accountRepository = accountRepository;
            
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {

            if (ModelState.IsValid)
            {

                var user = _accountRepository.GetUser(model.Name, _cryptor.Encrypt(model.Password));
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

            return View("Index"); //return View("Index",model)
        }

        [HttpGet]
        public PartialViewResult Register()
        {
            return PartialView("Registration", new RegisterModel());
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
            if (!ModelState.IsValid) return View("Index", model);
            var result = _accountRepository.AddUnique(new User(model.Name, _cryptor.Encrypt(model.Password)));
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

            return View("Index", model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}