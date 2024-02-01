using LeantIt.Web.Data;
using LeantIt.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeantIt.Web.Controllers
{
    public class TurismoController : Controller
    {
        private readonly UserManager<AplicacaoUser> _userManager;
        private readonly SignInManager<AplicacaoUser> _signInManager;
        private AppDbContext _context;
        public TurismoController(AppDbContext appContext, UserManager<AplicacaoUser> userManager, SignInManager<AplicacaoUser> signInManager) 
        {
            _context = appContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var idParaEncontrar = _signInManager.UserManager.GetUserId(User);
                var usuarioComNomeDeExibicao = _userManager.Users.FirstOrDefault(x => x.Id == idParaEncontrar);
                if (usuarioComNomeDeExibicao != null)
                {
                    ViewBag.User = usuarioComNomeDeExibicao.Nome;
                }
                var user = User.Identity.Name;
                var users = _signInManager.UserManager.Users.FirstOrDefault(userItem => userItem.UserName == user);

                var pendente = _context.AlguelCarros.FirstOrDefault(aluguelSelecionado => aluguelSelecionado.User == users.Id && aluguelSelecionado.Pendente == true);
                ViewBag.Pendente = pendente;
            }
            return View();
        }
    }
}
