using Microsoft.AspNetCore.Mvc;

namespace LeantIt.Web.Controllers
{
    public class TurismoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
