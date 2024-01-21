using LeantIt.Web.Areas.Identity.Pages.Account.Manage;
using LeantIt.Web.Data;
using LeantIt.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeantIt.Web.Controllers
{
    public class HistoricoController : Controller
    {
        private readonly ILogger<HistoricoController> _logger;
        private readonly SignInManager<AplicacaoUser> _signInManager;
        private AppDbContext _context;
        public HistoricoController(ILogger<HistoricoController> logger, AppDbContext context, SignInManager<AplicacaoUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity.Name;
                var users = _signInManager.UserManager.Users.FirstOrDefault(userItem => userItem.UserName == user);
                ViewBag.User = users;

                var aluguel = _context.AlguelCarros.Include(aluguelItem => aluguelItem.Carro).Include(aluguelItem => aluguelItem.Carro.Categoria).ToList();

                var pendente = _context.AlguelCarros.FirstOrDefault(aluguelSelecionado => aluguelSelecionado.User == users.Id && aluguelSelecionado.Pendente == true);
                ViewBag.Pendente = pendente;

                return View(aluguel);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
