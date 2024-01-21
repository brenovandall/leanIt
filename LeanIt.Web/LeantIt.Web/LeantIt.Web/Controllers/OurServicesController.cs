using LeantIt.Web.Data;
using LeantIt.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeantIt.Web.Controllers;


//***************************************************************************************//
//               ESTE É O CONTROLADOR DOS SERVIÇOS DO SISTEMA                            //
//***************************************************************************************//
public class OurServicesController : Controller
{

    private readonly ILogger<OurServicesController> _logger;
    private readonly SignInManager<AplicacaoUser> _signInManager;
    private AppDbContext _context;

    public OurServicesController(ILogger<OurServicesController> logger, AppDbContext context, SignInManager<AplicacaoUser> signInManager)
    {
        _logger = logger;
        _context = context;
        _signInManager = signInManager;
    }
    // essa view retorna a pagina de serviços da "empresa", os carros de cada categoria
    // os detalhes de cada categoria, etc...
    public IActionResult Index()
    {
        var carros = _context.Carros.ToList();
        var qntCarros = carros.Count();
        ViewBag.QntCarros = qntCarros;

        var pessoas = _context.Users.ToList();
        ViewBag.QntPessoas = pessoas.Count();

        if (User.Identity.IsAuthenticated)
        {

            var user = User.Identity.Name;
            var users = _signInManager.UserManager.Users.FirstOrDefault(userItem => userItem.UserName == user);

            var pendente = _context.AlguelCarros.FirstOrDefault(aluguelSelecionado => aluguelSelecionado.User == users.Id && aluguelSelecionado.Pendente == true);
            ViewBag.Pendente = pendente;
        }
        return View();
    }
}
