using Microsoft.AspNetCore.Mvc;

namespace LeantIt.Web.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
