using Microsoft.AspNetCore.Mvc;

namespace LeantIt.Web.Controllers
{
    public class TermosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
