using Microsoft.AspNetCore.Mvc;

namespace LeantIt.Web.Controllers;

//***************************************************************************************//
//               ESTE É O CONTROLADOR DO REGISTRO DE USUARIOS E LOGIN                    //
//***************************************************************************************//
public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }


    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
}
