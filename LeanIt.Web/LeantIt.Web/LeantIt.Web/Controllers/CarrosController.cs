﻿using LeantIt.Web.Data;
using LeantIt.Web.Models;
using LeantIt.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace LeantIt.Web.Controllers;

// ************************************************ //
// CONTROLADOR DAS ALTERAÇÕES E INSERÇÃO DE CARROS  //
// ************************************************ //
public class CarrosController : Controller
{
    private readonly ILogger<CarrosController> _logger;
    private readonly UserManager<AplicacaoUser> _userManager;
    private readonly SignInManager<AplicacaoUser> _signInManager;
    private AppDbContext _context; // este é o DbContext (contexto da base de dados usada no nosso projeto)
                                   // em todas os casos de tratamentos de dados, utilize "_context" para acessar as tabelas...

    // construtor do controller, aqui, devem ser assinadas todas as injeções de dependencias
    public CarrosController(ILogger<CarrosController> logger, AppDbContext context, SignInManager<AplicacaoUser> signInManager, UserManager<AplicacaoUser> userManager)
    {
        _logger = logger;
        _context = context;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    // Aqui a view retorna a página de adicionar
    [HttpGet]
    [Authorize(Roles ="Admin")]
    public IActionResult Adicionar()
    {
        var categorias = _context.Categorias.ToList();

        var adicionarCarroViewModel = new AdicionarCarroViewModel()
        {
            Categoria = categorias.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() })
        };
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
        return View(adicionarCarroViewModel);
    }

    // Aqui a view envia os dados da página "Adicionar"
    [HttpPost]
    public IActionResult Adicionar(AdicionarCarroViewModel adicionarCarroViewModel)
    {
        var idCategoria = Guid.Parse(adicionarCarroViewModel.CategoriaSelecionada);
        var selecionado = _context.Categorias.FirstOrDefault(x => x.Id == idCategoria);

        if (adicionarCarroViewModel != null)
        {
            var carro = new CarroModel()
            {
                Descricao = adicionarCarroViewModel.Descricao,
                Marca = adicionarCarroViewModel.Marca,
                Modelo = adicionarCarroViewModel.Modelo,
                Year = adicionarCarroViewModel.Year,
                Placa = adicionarCarroViewModel.Placa,
                Cor = adicionarCarroViewModel.Cor,
                UrlImagem = "none",
                Latitude = adicionarCarroViewModel.Latitude,
                Categoria = selecionado,
                Longitude = adicionarCarroViewModel.Longitude,
                Status = adicionarCarroViewModel.Status
            };

            _context.Carros.Add(carro);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }

        return View(null);
    }

    // Aqui a view retorna os dados para a pagina
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Listar(string sortOrder, int? page)
    {
        
        var carros = _context.Carros; // retorna os registros da tabela de carros do banco de dados
        int pageSize = 5; // Quantidade de itens que aparecerão por página
        int pageNumber = (page ?? 1); // Referência de qual página o usuário está no momento

        // SE FOR "Nome Crescente", ELE IRÁ CAIR NO case "nome_desc"
        // SE FOR "Nome Decrescente", ELE IRÁ CAIR NO case "nome_asc"
        // O VALOR DEFAULT É APENAS A LISTA DE CARROS NORMAL ASSIM COMO ESTÁ REGISTRADO NAS TABELAS
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
        switch (sortOrder)
        {
            case "nome_desc":
                var descOrder = carros.OrderByDescending(s => s.Marca);
                return View(descOrder.ToPagedList(pageNumber, pageSize));
            case "nome_asc":
                var ascOrder = carros.OrderBy(s => s.Marca);
                return View(ascOrder.ToPagedList(pageNumber, pageSize));
            default:
                var normalOrder = carros.OrderByDescending(s => s.Marca);
                return View(normalOrder.ToPagedList(pageNumber, pageSize));
        }
        
    }


    // Aqui a view retorna os dados para uma simples pagina de deletar o carro
    [HttpGet]
    [Authorize(Roles ="Admin")]
    public IActionResult Remover(Guid? id)
    {
        var carros = _context.Carros.ToList();

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

        foreach (var carro in carros)
        {
            if (id == carro.Id)
            {
                return View(carro);
            }
        }

        return RedirectToAction("Listar");
    }

    // Aqui a view efetivamente deleta o carro 
    [HttpPost]
    public IActionResult Remover(CarroModel carro)
    {
        var carros = _context.Carros.ToList();

        foreach (var carroItem in carros)
        {
            if (carroItem.Id == carro.Id)
            {
                _context.Carros.Remove(carroItem);
                _context.SaveChanges();
            }
        }

        return RedirectToAction("Listar");
    }

    // Aqui a view retorna os dados para fazer a edição de um carro, trazendo todos os dados do carro existente
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Editar(Guid id)
    {
        var carroDoBancoDeDados = _context.Carros.Include(x => x.Categoria).FirstOrDefault(x => x.Id == id);

        var categoriaSelecionada = _context.Categorias.FirstOrDefault(x => x.Id == carroDoBancoDeDados.Categoria.Id);

        var categorias = _context.Categorias.ToList();

        var novoModel = new EditarCarroViewModel()
        {
            Id = carroDoBancoDeDados.Id,
            Descricao = carroDoBancoDeDados.Descricao,
            Marca = carroDoBancoDeDados.Marca,
            Modelo = carroDoBancoDeDados.Modelo,
            Year = carroDoBancoDeDados.Year,
            Placa = carroDoBancoDeDados.Placa,
            Cor = carroDoBancoDeDados.Cor,
            UrlImagem = "none",
            Latitude = carroDoBancoDeDados.Latitude,
            Longitude = carroDoBancoDeDados.Longitude,
            Categoria = categorias.Select(x => new SelectListItem { Text = x.Descricao, Value = x.Id.ToString() }),
            CategoriaSelecionada = categoriaSelecionada.Id.ToString(),
            Status = carroDoBancoDeDados.Status
        };

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


        return View(novoModel);
    }

    // Aqui a view envia os dados atualizados e efetua uma atualização nas colunas
    [HttpPost]
    public IActionResult Editar(EditarCarroViewModel editarCarroViewModel)
    {
        var carroAntigo = _context.Carros.FirstOrDefault(x => x.Id == editarCarroViewModel.Id);

        var idCategoria = Guid.Parse(editarCarroViewModel.CategoriaSelecionada);

        var selecionado = _context.Categorias.FirstOrDefault(x => x.Id == idCategoria);

        if (carroAntigo != null)
        {

            carroAntigo.Descricao = editarCarroViewModel.Descricao;
            carroAntigo.Marca = editarCarroViewModel.Marca;
            carroAntigo.Modelo = editarCarroViewModel.Modelo;
            carroAntigo.Year = editarCarroViewModel.Year;
            carroAntigo.Placa = editarCarroViewModel.Placa;
            carroAntigo.Cor = editarCarroViewModel.Cor;
            carroAntigo.UrlImagem = editarCarroViewModel.UrlImagem;
            carroAntigo.Latitude = editarCarroViewModel.Latitude;
            carroAntigo.Longitude = editarCarroViewModel.Longitude;
            carroAntigo.Categoria = selecionado;
            carroAntigo.Status = editarCarroViewModel.Status;

            _context.SaveChanges();
        }

        return RedirectToAction("Listar");
    }
}
