using LeantIt.Web.Data;
using LeantIt.Web.Models;
using LeantIt.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LeantIt.Web.Controllers;

public class CarrosController : Controller
{

    private AppDbContext _context;

    public CarrosController(AppDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public IActionResult Adicionar()
    {
        return View();
    }


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
    [HttpGet]
    public IActionResult Listar() {

        var carros = _context.Carros.ToList();
        return View(carros);
    }
}
