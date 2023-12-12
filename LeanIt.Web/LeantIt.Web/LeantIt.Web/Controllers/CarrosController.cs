using LeantIt.Web.Data;
using LeantIt.Web.Models;
using LeantIt.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LeantIt.Web.Controllers;

// ************************************************ //
// CONTROLADOR DAS ALTERAÇÕES E INSERÇÃO DE CARROS  //
// ************************************************ //
public class CarrosController : Controller
{

    private AppDbContext _context; // este é o DbContext (contexto da base de dados usada no nosso projeto)
                                   // em todas os casos de tratamentos de dados, utilize "_context" para acessar as tabelas...

    // construtor do controller, aqui, devem ser assinadas todas as injeções de dependencias
    public CarrosController(AppDbContext context)
    {
        _context = context;
    }

    // Aqui a view retorna a página de adicionar
    [HttpGet]
    public IActionResult Adicionar()
    {
        return View();
    }

    // Aqui a view envia os dados da página "Adicionar"
    [HttpPost]
    public IActionResult Adicionar(AdicionarCarroViewModel adicionarCarroViewModel)
    {
        
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
                Status = adicionarCarroViewModel.Status,
                Latitude = adicionarCarroViewModel.Latitude,
                Longitude = adicionarCarroViewModel.Longitude
            };

            _context.Carros.Add(carro);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }

        return View(null);
    }

    // Aqui a view retorna os dados para a pagina
    [HttpGet]
    public IActionResult Listar() {

        var carros = _context.Carros.ToList();
        return View(carros);
    }


    // Aqui a view retorna os dados para uma simples pagina de deletar o carro
    [HttpGet]
    public IActionResult Remover(Guid? id)
    {
        var carros = _context.Carros.ToList();

        foreach(var carro in carros)
        {
            if(id == carro.Id)
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
    public IActionResult Editar(Guid? id)
    {
        var carros = _context.Carros.ToList();

        foreach (var carro in carros)
        {
            if (id == carro.Id)
            {
                return View(carro);
            }
        }
        return RedirectToAction("Index", "Home");
    }

    // Aqui a view envia os dados atualizados e efetua uma atualização nas colunas
    [HttpPost]
    public IActionResult Editar(CarroModel carro)
    {
        var carros = _context.Carros.ToList();

        foreach(var carroItem in carros){

            if (carro.Id == carroItem.Id){

                carroItem.Descricao = carro.Descricao;
                carroItem.Marca = carro.Marca;
                carroItem.Modelo = carro.Modelo;
                carroItem.Year = carro.Year;
                carroItem.Placa = carro.Placa;
                carroItem.Cor = carro.Cor;
                carroItem.Status = carro.Status;
                carroItem.Latitude = carro.Latitude;
                carroItem.Longitude = carro.Longitude;

                _context.Update(carroItem);
                _context.SaveChanges();
            }
        }
        return RedirectToAction("Listar");
    }
}
