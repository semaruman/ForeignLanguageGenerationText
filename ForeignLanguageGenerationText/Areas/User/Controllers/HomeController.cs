using CodeCareer.Areas.User.Models;
using ForeignLanguageGenerationText.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForeignLanguageGenerationText.Areas.User.Controllers
{
    [Area("User")]
    [Route("")]
    [Route("{area}")]
    [Route("{area}/{action}")]
    public class HomeController : Controller
    {
        public UserModel currentUser = new UserModel();

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Authorization()
        {
            return View(currentUser);
        }

        [HttpPost]
        public IActionResult Authorization(UserModel user)
        {
            if (ModelState.IsValid)
            {
                UserModelDb db = new UserModelDb();

                var dbUser = db.GetUserModels().Where(u => u.UserName == user.UserName).FirstOrDefault();



                // Если пользователь не найден в БД
                if (dbUser == null)
                {
                    currentUser = new UserModel
                    {
                        UserName = user.UserName,
                        Password = user.Password,
                        LearnedWords = new List<string>()
                    };
                    db.AddUserModel(currentUser);
                    return RedirectToAction("SuccessAuthorization");
                }
                else
                {
                    if (dbUser.Password == user.Password)
                    {
                        currentUser = dbUser;
                        return RedirectToAction("SuccessAuthorization");
                    }
                    else
                    {
                        ViewBag.WrongPassword = "Неверный пароль!";
                        return View(user);
                    }
                }
            }
            else
            {
                return View(user);
            }
        }

        public IActionResult SuccessAuthorization()
        {
            return View();
        }
    }
}