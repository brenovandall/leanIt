using LeantIt.Web.Data;
using LeantIt.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Diagnostics;
using LeantIt.Web.Migrations;

namespace LeantIt.Web.Controllers
{
    public class PagamentoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<AplicacaoUser> _signInManager;
        private readonly UserManager<AplicacaoUser> _userManager;

        public PagamentoController(AppDbContext context, SignInManager<AplicacaoUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index(Guid? id)
        {
            var user = User.Identity.Name;
            var users = _signInManager.UserManager.Users.FirstOrDefault(userItem => userItem.UserName == user);

            var pagamento = _context.AlguelCarros.Include(aluguel => aluguel.Carro).Include(aluguel => aluguel.Carro.Categoria).FirstOrDefault(aluguel => aluguel.User == users.Id && aluguel.Pendente == true);

            switch(pagamento.Carro.Categoria.Descricao)
            {
                case "Basico":
                    ViewBag.Aluguel = (pagamento.Minutos / 60 * 12) + 12;
                    break;
                case "Carga":
                    ViewBag.Aluguel = (pagamento.Minutos / 60 * 21) + 21;
                    break;
                case "Familia":
                    ViewBag.Aluguel = (pagamento.Minutos / 60 * 15) + 15;
                    break;

            }
            return View(pagamento);
        }

        [HttpPost]
        public IActionResult Index(AluguelCarros aluguelCarros)
        {
            if (User.Identity.IsAuthenticated)
            {

                var user = User.Identity.Name;
                var users = _signInManager.UserManager.Users.FirstOrDefault(userItem => userItem.UserName == user);

                var pagamento = _context.AlguelCarros.Include(aluguel => aluguel.Carro).Include(aluguel => aluguel.Carro.Categoria).FirstOrDefault(aluguel => aluguel.User == users.Id && aluguel.Pendente == true);

                double valor = 0;

                switch (pagamento.Carro.Categoria.Descricao)
                {
                    case "Basico":
                        valor = (pagamento.Minutos / 60 * 12) + 12;
                        break;
                    case "Carga":
                        valor = (pagamento.Minutos / 60 * 21) + 21;
                        break;
                    case "Familia":
                        valor = (pagamento.Minutos / 60 * 15) + 15;
                        break;

                }
                if (Math.Abs(valor - aluguelCarros.Preco) < 0.01)
                {

                    pagamento.Carro.Status = true;
                    pagamento.Pendente = false;
                    pagamento.Preco = aluguelCarros.Preco;   
                    _context.SaveChanges();
                    return RedirectToAction("PagamentoRealizado", new {id = pagamento.Id});
                }
     
            }

            return RedirectToAction("Index", "Pagamento");
        }

        [HttpGet]
        public IActionResult PagamentoRealizado(Guid? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity.Name;
                var users = _signInManager.UserManager.Users.FirstOrDefault(userItem => userItem.UserName == user);

                var alguelFeito = _context.AlguelCarros.FirstOrDefault(aluguelItem => aluguelItem.Id == id && aluguelItem.User == users.Id && aluguelItem.Pendente == false);

                ViewBag.AluguelFeito = alguelFeito;

                return View(alguelFeito);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> PagamentoRealizado(AluguelCarros aluguelCarros)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity.Name;
                var users = _signInManager.UserManager.Users.FirstOrDefault(userItem => userItem.UserName == user);

                var aluguel = _context.AlguelCarros.FirstOrDefault(aluguelItem => aluguelItem.User == users.Id && aluguelItem.Pendente == false);

                if(aluguel is not null)
                {
                    aluguel.Avaliacao_Estrelas = aluguelCarros.Avaliacao_Estrelas;
                    aluguel.Avaliacao_Descricao_Feedback = aluguelCarros.Avaliacao_Descricao_Feedback;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}

