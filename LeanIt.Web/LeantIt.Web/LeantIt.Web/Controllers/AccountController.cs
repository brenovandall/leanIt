using Microsoft.AspNetCore.Mvc;

namespace LeantIt.Web.Controllers;

//***************************************************************************************//
//               ESTE É O CONTROLADOR DO REGISTRO DE USUARIOS E LOGIN                    //
//***************************************************************************************//
public class AccountController : Controller
{
    // aqui, a view retorna a tela de login, na qual tem um link para direcionar o usuario
    // que nao está regitrado no sistema, para a tela de cadastro
    public IActionResult Login()
    {
        return View();
    }

    // aqui, a view retorna a tela de registro de usuario (cadastro no sistema)
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
}
