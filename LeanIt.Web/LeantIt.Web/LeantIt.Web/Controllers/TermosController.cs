using LeantIt.Web.Data;
using LeantIt.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeantIt.Web.Controllers
{
    public class TermosController : Controller
    {
        private readonly ILogger<TermosController> _logger;
        private readonly SignInManager<AplicacaoUser> _signInManager;
        private readonly UserManager<AplicacaoUser> _userManager;
        private AppDbContext _context;

        public TermosController(ILogger<TermosController> logger, AppDbContext context, SignInManager<AplicacaoUser> signInManager, UserManager<AplicacaoUser> userManager)
        {
            _logger = logger;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
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
}
