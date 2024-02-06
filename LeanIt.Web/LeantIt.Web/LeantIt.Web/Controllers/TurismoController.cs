﻿using LeantIt.Web.Data;
using LeantIt.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeantIt.Web.Controllers
{
    public class TurismoController : Controller
    {
        private readonly ILogger<TurismoController> _logger;
        private readonly SignInManager<AplicacaoUser> _signInManager;
        private readonly UserManager<AplicacaoUser> _userManager;
        private AppDbContext _context;

        public TurismoController(ILogger<TurismoController> logger, AppDbContext context, SignInManager<AplicacaoUser> signInManager, UserManager<AplicacaoUser> userManager)
        {
            _logger = logger;
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
            return View();
        }
    }
}
