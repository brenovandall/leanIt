using LeantIt.Web.Data;
using LeantIt.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LeantIt.Web.Controllers
{
    public class CarroEscolhidoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<AplicacaoUser> _signInManager;
        private readonly UserManager<AplicacaoUser> _userManager;

        public CarroEscolhidoController(AppDbContext context, SignInManager<AplicacaoUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index(Guid? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity.Name;
                var users = _signInManager.UserManager.Users.FirstOrDefault(userItem => userItem.UserName == user);
                ViewBag.User = users.Nome;
                var pendente = _context.AlguelCarros.FirstOrDefault(aluguelSelecionado => aluguelSelecionado.User == users.Id && aluguelSelecionado.Pendente == true);

                ViewBag.Pendente = pendente;
            }

            var carroEscolhido = _context.Carros.Include(carro => carro.Categoria).FirstOrDefault(carro => carro.Id == id);

            return View(carroEscolhido);
        }

        [HttpPost]
        public IActionResult Index(CarroModel carro)
        {
            var user = User.Identity.Name;
            var users = _signInManager.UserManager.Users.FirstOrDefault(userItem => userItem.UserName == user);
            
            if (carro != null)
            {
                var carros = _context.Carros.FirstOrDefault(carroItem => carroItem.Id == carro.Id);
                carros.Status = false;

                AluguelCarros aluguel = new AluguelCarros();
                aluguel.Minutos = 0;
                aluguel.Carro = carros;
                aluguel.User = users.Id;
                aluguel.Pendente = true;
                aluguel.Avaliacao_Descricao_Feedback = String.Empty;
                aluguel.Avaliacao_Estrelas = 0;

                _context.AlguelCarros.Add(aluguel);
                _context.SaveChanges();

                return RedirectToAction("Alugado", "CarroEscolhido", new {id = aluguel.Id});
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Alugado(Guid? id)
        {
            var user = User.Identity.Name;
            var users = _signInManager.UserManager.Users.FirstOrDefault(userItem => userItem.UserName == user);
            ViewBag.User = users.Nome;
            var pendente = _context.AlguelCarros.FirstOrDefault(aluguelSelecionado => aluguelSelecionado.User == users.Id && aluguelSelecionado.Pendente == true);

            ViewBag.Pendente = pendente;

            var aluguelCarro = _context.AlguelCarros.Include(aluguel => aluguel.Carro).Include(aluguel => aluguel.Carro.Categoria).FirstOrDefault(aluguel => aluguel.Id == id);

            return View(aluguelCarro);
        }

        [HttpPost]
        public IActionResult Alugado(AluguelCarros aluguelCarros)
        {
            if (User.Identity.IsAuthenticated)
            {

                var user = User.Identity.Name;
                var users = _signInManager.UserManager.Users.FirstOrDefault(userItem => userItem.UserName == user);

                var pendente = _context.AlguelCarros.FirstOrDefault(aluguelSelecionado => aluguelSelecionado.User == users.Id && aluguelSelecionado.Pendente == true);
                ViewBag.Pendente = pendente;

                pendente.Minutos = aluguelCarros.Minutos;
                _context.SaveChanges();

                return RedirectToAction("Index", "Pagamento", new { id = pendente.Id });
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Pendente()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity.Name;
                var users = _signInManager.UserManager.Users.FirstOrDefault(userItem => userItem.UserName == user);
                ViewBag.User = users.Nome;
                var pendente = _context.AlguelCarros.Include(aluguel => aluguel.Carro).FirstOrDefault(aluguelSelecionado => aluguelSelecionado.User == users.Id && aluguelSelecionado.Pendente == true);

                return RedirectToAction("Alugado", new { id = pendente.Id });
            }

            return RedirectToAction("Index", "Home");
        }
    }
}