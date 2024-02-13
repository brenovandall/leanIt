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

            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity.Name;
                var users = _signInManager.UserManager.Users.FirstOrDefault(userItem => userItem.UserName == user);
                ViewBag.User = users.Nome;
                ViewBag.Users = users;
        
                var pendente = _context.AlguelCarros.FirstOrDefault(aluguelSelecionado => aluguelSelecionado.User == users.Id && aluguelSelecionado.Pendente == true);
                ViewBag.Pendente = pendente;

                var aluguel = _context.AlguelCarros.Include(item => item.Carro).Include(item => item.Carro.Categoria).Where(item => item.Pendente == false && item.User == users.Id).ToList();

                var qnt = _context.AlguelCarros.FirstOrDefault(aluguel => aluguel.User == users.Id);
                ViewBag.Qnt = qnt;

                var foto = users.ImagemDePerfil;
                ViewBag.Foto = foto;

                return View(aluguel.ToPagedList(pageNumber, pageSize));
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
