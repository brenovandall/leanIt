using Microsoft.AspNetCore.Mvc;

namespace LeantIt.Web.Controllers;

public class OurServicesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
