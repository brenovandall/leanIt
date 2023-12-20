using Microsoft.AspNetCore.Mvc;

namespace LeantIt.Web.Controllers
{
    public class SaibaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
