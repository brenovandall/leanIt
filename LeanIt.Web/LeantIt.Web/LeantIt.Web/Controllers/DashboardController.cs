using LeantIt.Web.Data;
using LeantIt.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeantIt.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<AplicacaoUser> _signInManager;
        private readonly UserManager<AplicacaoUser> _userManager;

        public DashboardController(AppDbContext context, SignInManager<AplicacaoUser> signInManager, UserManager<AplicacaoUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
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

            var categoriaBasico = _context.Categorias.FirstOrDefault(categoriaCarro => categoriaCarro.Descricao == "Basico");
            var carroBasico = _context.AlguelCarros.Where(aluguelCarro => aluguelCarro.Carro.Categoria.Descricao == categoriaBasico.Descricao).Count();
            ViewBag.CarroBasico = carroBasico;


            var categoriaFamilias = _context.Categorias.FirstOrDefault(categoriaF => categoriaF.Descricao == "Familia");
            var carroFamilia = _context.AlguelCarros.Where(carroF => carroF.Carro.Categoria.Descricao == categoriaFamilias.Descricao).Count();
            ViewBag.CarroFamilia = carroFamilia;


            var categoriaCarga = _context.Categorias.FirstOrDefault(categoriaC => categoriaC.Descricao == "Carga");
            var carroCarga = _context.AlguelCarros.Where(carroC => carroC.Carro.Categoria.Descricao == categoriaCarga.Descricao).Count();
            ViewBag.CarroCarga = carroCarga;




            var carroAtivo = _context.Carros.Where(carroA => carroA.Status == true).Count();
            ViewBag.CarroAtivo = carroAtivo;

            var carroInativo = _context.Carros.Where(carroI => carroI.Status == false).Count();
            ViewBag.CarroInativo = carroInativo;



            var qCarrosBasico = _context.Carros.Where(QCarro => QCarro.Categoria.Descricao == "Basico").Count();
            ViewBag.QCarroBasico = qCarrosBasico;

            var qCarrosFamilia = _context.Carros.Where(QCarro => QCarro.Categoria.Descricao == "Familia").Count();
            ViewBag.QCarroFamilia = qCarrosFamilia;

            var qCarrosCarga = _context.Carros.Where(QCarro => QCarro.Categoria.Descricao == "Carga").Count();
            ViewBag.QCarroCarga = qCarrosCarga;

            return View();
        }
    }
}
