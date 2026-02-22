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

    }
}