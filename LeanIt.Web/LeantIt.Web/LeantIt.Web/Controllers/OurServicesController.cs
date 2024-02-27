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
    private readonly UserManager<AplicacaoUser> _userManager;
    private AppDbContext _context;

    public OurServicesController(ILogger<OurServicesController> logger, AppDbContext context, SignInManager<AplicacaoUser> signInManager, UserManager<AplicacaoUser> userManager)
    {
        _logger = logger;
        _context = context;
        _signInManager = signInManager;
        _userManager = userManager;
    }
    // essa view retorna a pagina de serviços da "empresa", os carros de cada categoria
    // os detalhes de cada categoria, etc...
    public IActionResult Index()
    {
        //Tranformamos a tabela de Carros em lista e armazenamos em uma váriavel
        var carros = _context.Carros.ToList();

        //Pegamos a variável acima, e verificamos QUANTOS registro possuem nela
        var qntCarros = carros.Count();

        //Armazenamos em uma ViewBag o valor que está na variável acima, para poder utilizar no front
        ViewBag.QntCarros = qntCarros;


        //Tranformamos a tabela de Users em lista e armazenamos em uma váriavel
        var pessoas = _context.Users.ToList();

        //Armazenamos em uma ViewBag o valor da QUANTIDADE de registros que retornou na váriavel acima, para poder utilizar no front 
        ViewBag.QntPessoas = pessoas.Count();

        //Verifica se o usuário está autenticado
        if (User.Identity.IsAuthenticated)
        {
            //Pega o id do usuário que está logado
            var idParaEncontrar = _signInManager.UserManager.GetUserId(User);

            //Verifica se existe o id do usuário logado no banco
            var usuarioComNomeDeExibicao = _userManager.Users.FirstOrDefault(x => x.Id == idParaEncontrar);

            //Se encontrar o id do usuário logado no banco a variável usuarioComNomeDeExibicao vai ter um valor, ou seja, ela não será nula, então ela vai para o if
            if (usuarioComNomeDeExibicao != null)
            {
                //Pega o nome do usuário logado e armazenamos em uma ViewBag, para poder usar no front
                ViewBag.User = usuarioComNomeDeExibicao.Nome;
            }

            //Armazena na variável o name do usuário autenticado
            var user = User.Identity.Name;

            //Verifica se no banco possui o name do usuário autenticado, se tiver vai armazena na variável o registro do usuário
            var users = _signInManager.UserManager.Users.FirstOrDefault(userItem => userItem.UserName == user);

            //Verifica se o usuário que tá logado possui alguma pendência de aluguel na tabela AluguelCarros
            var pendente = _context.AlguelCarros.FirstOrDefault(aluguelSelecionado => aluguelSelecionado.User == users.Id && aluguelSelecionado.Pendente == true);

            //Armazena o registro da verificação acima, está em uma ViewBag  para poder usar no front
            ViewBag.Pendente = pendente;
        }
        return View();
    }
}
