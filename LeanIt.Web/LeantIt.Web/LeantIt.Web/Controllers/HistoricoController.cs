using LeantIt.Web.Data;
using LeantIt.Web.Models;
using LeantIt.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;


namespace LeantIt.Web.Controllers
{
    public class HistoricoController : Controller
    {
        private readonly ILogger<HistoricoController> _logger;
        private readonly SignInManager<AplicacaoUser> _signInManager;
        private readonly UserManager<AplicacaoUser> _userManager;
        private AppDbContext _context;
        public HistoricoController(ILogger<HistoricoController> logger, AppDbContext context, SignInManager<AplicacaoUser> signInManager, UserManager<AplicacaoUser> userManager)
        {
            _logger = logger;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);


            //Verifica se o usuário está autenticado
            if (User.Identity.IsAuthenticated)
            {
                //Armazena na variável o name do usuário autenticado
                var user = User.Identity.Name;

                //Verifica se no banco possui o name do usuário autenticado, se tiver vai armazena na variável o registro do usuário
                var users = _signInManager.UserManager.Users.FirstOrDefault(userItem => userItem.UserName == user);

                //Do registro da variável acima, é pego o dado de Nome e armazenado em uma ViewBag, para poder usar no front
                ViewBag.User = users.Nome;
                
                //Armazena os registros do usuário logado
                ViewBag.Users = users;

                //Verifica se o usuário que tá logado possui alguma pendência de aluguel na tabela AluguelCarros
                var pendente = _context.AlguelCarros.FirstOrDefault(aluguelSelecionado => aluguelSelecionado.User == users.Id && aluguelSelecionado.Pendente == true);

                //Armazena o registro da verificação acima, está em uma ViewBag  para poder usar no front
                ViewBag.Pendente = pendente;

                //Transformamos a tabela de AlguelCarros em lista, fizemos validações, e demos o include para acessarmos os dados relacionados.
                var aluguel = _context.AlguelCarros.Include(item => item.Carro).Include(item => item.Carro.Categoria).Where(item => item.Pendente == false && item.User == users.Id).ToList();

                //Faz a verificação se o usuário logado, tem algum aluguel já finalizado
                var qnt = _context.AlguelCarros.FirstOrDefault(aluguel => aluguel.User == users.Id && aluguel.Pendente == false);

                //Passa o valor da váriavel acima para a ViewBag, para utilizar no front
                ViewBag.Qnt = qnt;

                //Armazena na variável o dado de imagem do Usuário que está logado 
                var foto = users.ImagemDePerfil;

                //Passa o valor da váriavel acima para a ViewBag, para utilizar no front
                ViewBag.Foto = foto;

                return View(aluguel.ToPagedList(pageNumber, pageSize));
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
