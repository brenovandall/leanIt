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
    public class ChatBotController : Controller
    {
        private readonly ILogger<CarrosController> _logger;
        private readonly UserManager<AplicacaoUser> _userManager;
        private readonly SignInManager<AplicacaoUser> _signInManager;
        private AppDbContext _context;

        public ChatBotController(ILogger<CarrosController> logger, UserManager<AplicacaoUser> userManager, SignInManager<AplicacaoUser> signInManager, AppDbContext context)
        {
            _context = context;
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

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

            var bot = _context.RespostaChat.ToList();

            return View(bot.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult AdicionarMP()
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

            RespostaChat resposta = new RespostaChat();

            return View(resposta);
        }

        [HttpPost]
        public IActionResult AdicionarMP(RespostaChat respostaChat)
        {
            if(respostaChat.Resposta != null && respostaChat.Mensagem != null)
            {
                _context.RespostaChat.Add(respostaChat);
                _context.SaveChanges();

                return RedirectToAction("AdicionarMP", "ChatBot");
            }

            return RedirectToAction("AdicionarMP", "ChatBot");
        }

        [HttpGet]
        public IActionResult Remover(int? id)
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

            var itemParaRemover = _context.RespostaChat.FirstOrDefault(item => item.Id == id);

            return View(itemParaRemover);
        }

        [HttpPost]
        public IActionResult Remover(RespostaChat respostaChat)
        {
            var itemRemovido = _context.RespostaChat.FirstOrDefault(item => item.Id == respostaChat.Id);
            _context.RespostaChat.Remove(itemRemovido);
            _context.SaveChanges();

            return RedirectToAction("Index", "ChatBot");
        }

        [HttpGet]
        public IActionResult Editar(int? id)
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

            var itemParaEditar = _context.RespostaChat.FirstOrDefault(item => item.Id == id);

            return View(itemParaEditar);
        }

        [HttpPost]
        public IActionResult Editar(RespostaChat respostaChat)
        {
            if(respostaChat.Mensagem != null && respostaChat.Resposta != null)
            {
                var itemRemovido = _context.RespostaChat.FirstOrDefault(item => item.Id == respostaChat.Id);
                itemRemovido.Resposta = respostaChat.Resposta;
                itemRemovido.Mensagem = respostaChat.Mensagem;

                _context.SaveChanges();
                return RedirectToAction("Index", "ChatBot");
            }

            return RedirectToAction("Index", "ChatBot");
        }
    }
}
