using Microsoft.AspNetCore.Mvc;

namespace LeantIt.Web.Controllers;


//***************************************************************************************//
//               ESTE É O CONTROLADOR DOS SERVIÇOS DO SISTEMA                            //
//***************************************************************************************//
public class OurServicesController : Controller
{
    // essa view retorna a pagina de serviços da "empresa", os carros de cada categoria
    // os detalhes de cada categoria, etc...
    public IActionResult Index()
    {
        return View();
    }
}
